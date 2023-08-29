using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField]
    private string _inputAxis = "Fire1";
    [SerializeField]
    private Spawner _spawner;

    private void Update()
    {
        if (Input.GetButtonDown(_inputAxis))
        {
            _spawner.Spawn();
        }
    }
}
