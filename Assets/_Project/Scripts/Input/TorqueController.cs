using UnityEngine;

public class TorqueController : MonoBehaviour
{
    [SerializeField]
    private string _inputAxisName = "Horizontal";
    [SerializeField]
    private float _torque = 1.0f;
    [SerializeField]
    private float _maxAngularVelocity = 1.0f;
    private Rigidbody2D _rigidbody2D;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var force = Input.GetAxis(_inputAxisName) * _torque;

        _rigidbody2D.AddTorque(force);
        _rigidbody2D.angularVelocity = Mathf.Clamp(_rigidbody2D.angularVelocity, -_maxAngularVelocity, _maxAngularVelocity); // TODO: Clamp torque using if statments
    }
}
