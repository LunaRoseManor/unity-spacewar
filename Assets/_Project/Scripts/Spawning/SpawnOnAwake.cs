using UnityEngine;

public class SpawnOnAwake : MonoBehaviour
{
    private Spawner _spawner;

    void Awake()
    {
        _spawner = GetComponent<Spawner>();
        _spawner.Spawn();
    }
}
