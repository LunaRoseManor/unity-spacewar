using UnityEngine;
using UnityEngine.Events;

public class InvokeOnAwake : MonoBehaviour
{
    public static UnityEvent<GameObject> Event = new UnityEvent<GameObject>();

    void Awake()
    {
        Event?.Invoke(gameObject);
    }
}
