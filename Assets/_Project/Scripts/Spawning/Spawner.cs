using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefabToInstantiate;
    private GameObject _instance;

    public GameObject Spawn()
    {
        var clone = Instantiate(_prefabToInstantiate, transform.position, transform.rotation);
        _instance = clone;

        return clone;
    }

    public void Spawn(int instanceQuantity)
    {
        Debug.Assert(instanceQuantity > 0);

        for (int i = 0; i < instanceQuantity; i++)
        {
            Spawn();
        }
    }

    public GameObject GetPrefabInstance()
    {
        return _instance;
    }
}
