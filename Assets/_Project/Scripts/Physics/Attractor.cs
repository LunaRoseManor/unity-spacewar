using UnityEngine;

public class Attractor : MonoBehaviour
{
    [SerializeField]
    private bool _attractable = true;

    void Awake()
    {
        
    }

    public bool IsAttractable()
    {
        return _attractable;
    }
}
