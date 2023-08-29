using UnityEngine;

public class RespawnAfterDestroy : MonoBehaviour
{
    private Spawner _spawner;

    void Awake()
    {
        _spawner = GetComponent<Spawner>();
        InvokeOnDestroy.Event.AddListener(OnPrefabDestroy);
    }

    private void OnPrefabDestroy(GameObject gameObject)
    {
        if (!gameObject.scene.isLoaded) return;

        // Spawn a new prefab only if the GameObject that sent this message
        // matches the one stored in the spawner itself
        if (gameObject.GetInstanceID() == _spawner.GetPrefabInstance().GetInstanceID())
        {
            _spawner.Spawn();
        }
    }
}
