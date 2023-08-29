using UnityEngine;

public class ThrustController : MonoBehaviour
{
    [SerializeField]
    private string _inputAxisName = "Vertical";
    [SerializeField]
    private float _speed = 1.0f;
    [SerializeField]
    private float _maxVelocity = 1.0f;
    private Rigidbody2D _rigidbody2D;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var force = Input.GetAxis(_inputAxisName) * _speed;

        _rigidbody2D.AddRelativeForce(Vector2.up * force);
        _rigidbody2D.velocity = Vector2.ClampMagnitude(_rigidbody2D.velocity, _maxVelocity); // TODO: Clamp velocity using if statements
    }
}
