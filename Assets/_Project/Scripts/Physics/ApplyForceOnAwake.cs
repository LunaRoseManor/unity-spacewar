using UnityEngine;

public class ApplyForceOnAwake : MonoBehaviour
{
    [SerializeField]
    private Vector2 _force = Vector2.zero;
    private Rigidbody2D _rigidbody2D;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddRelativeForce(_force);
    }
}
