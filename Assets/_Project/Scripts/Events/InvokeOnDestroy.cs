using UnityEngine;
using UnityEngine.Events;

public class InvokeOnDestroy : MonoBehaviour
{
    public static UnityEvent<GameObject> Event = new UnityEvent<GameObject>();

    private void OnDestroy()
    {
        Event?.Invoke(gameObject);
    }
}
