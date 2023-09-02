using UnityEngine;
using UnityEngine.Events;

public class UpdateScoreOnObjectDestroy : MonoBehaviour
{
    [SerializeField]
    private string _name = string.Empty;

    private void Awake()
    {
        InvokeOnDestroy.Event.AddListener(OnGameObjectDestroy);
    }

    private void OnGameObjectDestroy(GameObject gameObject)
    {
        if (gameObject.name == _name)
        {

        }
    }
}
