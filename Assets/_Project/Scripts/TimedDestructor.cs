using UnityEngine;

public class TimedDestructor : MonoBehaviour
{
    [SerializeField]
    private float _duration = 1.0f;
    private float _time = 0.0f;

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time > _duration)
        {
            Destroy(gameObject);
        }
    }
}
