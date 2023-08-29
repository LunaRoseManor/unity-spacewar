using UnityEngine;

public class InstantiateOnDestroy : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _prefabs;

    void Awake()
    {
        InvokeOnDestroy.Event.AddListener(OnMessengerDestroy);
    }

    void OnMessengerDestroy(GameObject gameObject)
    {
        // Safety check that must be included when doing things like this
        // Should help with potential memory leaks
        if (!gameObject.scene.isLoaded) return;

        if (_prefabs.Length > 0 && gameObject.GetInstanceID() == base.gameObject.GetInstanceID())
        {
            for (int i = 0; i < _prefabs.Length; i++)
            {
                // Instantiate a new prefab at the location of this game object
                var clone = Instantiate(_prefabs[i]);
                clone.transform.position = transform.position;
            }
        }
    }
}
