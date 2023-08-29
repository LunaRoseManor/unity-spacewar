using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gravitator : MonoBehaviour
{
    [SerializeField]
    private static float _gravity = 1.0f;
    [SerializeField]
    private List<string> _tagsAttractedToObject = new List<string>();
    private Rigidbody2D _rigidbody2D;
    private List<Rigidbody2D> _targets = new List<Rigidbody2D>();

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        // Make a list of every game object with a tag included in the list
        GenerateTargetList();

        // Use event listeners to update the list dynamically
        InvokeOnAwake.Event.AddListener(OnTargetAwake);
        InvokeOnDestroy.Event.AddListener(OnTargetDestroyed);
    }

    private void FixedUpdate()
    {
        foreach (Rigidbody2D target in _targets)
        {
            AddGravityForce(_rigidbody2D, target);
        }
    }

    public static void AddGravityForce(Rigidbody2D attractor, Rigidbody2D target)
    {
        // Obtain the mass product for each object
        float massProduct = attractor.mass * target.mass * _gravity;

        // Calculate the distance between the two objects
        Vector3 difference = attractor.position - target.position;
        float distance = difference.magnitude;

        // Calculate how much force should be applied depending on the distance
        float unscaledForceMagnitude = massProduct / Mathf.Pow(distance, 2);
        float forceMagnitude = _gravity * unscaledForceMagnitude;

        // Normalise the direction of the force
        Vector3 forceDirection = difference.normalized;

        // Apply the force calculated to the game objects
        Vector3 forceVector = forceDirection * forceMagnitude;
        target.AddForce(forceVector);
    }

    private void GenerateTargetList()
    {
        foreach (string tag in _tagsAttractedToObject)
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);

            foreach (GameObject gameObject in gameObjects)
            {
                Rigidbody2D rigidbody2D = gameObject.GetComponent<Rigidbody2D>();

                if (rigidbody2D != null)
                {
                    _targets.Add(rigidbody2D);
                }
            }
        }
    }

    private void OnTargetAwake(GameObject gameObject)
    {
        if (_tagsAttractedToObject.Contains(gameObject.tag) && gameObject.GetComponent<Rigidbody2D>() != null)
        {
            _targets.Add(gameObject.GetComponent<Rigidbody2D>());
        }
    }

    // This event is invoked primarily by the InvokeOnDestroy class
    private void OnTargetDestroyed(GameObject gameObject)
    {
        // Walk backwards through the list and remove all the matching objects
        // This prevents null references as the game state evolves
        for (int i = _targets.Count - 1; i >= 0; i--)
        {
            if (gameObject.GetInstanceID() == _targets[i].gameObject.GetInstanceID())
            {
                _targets.RemoveAt(i);
            }
        }
    }
}
