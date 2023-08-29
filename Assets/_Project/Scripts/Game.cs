using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance;
    public enum State
    {
        Paused,
        Playing,
        Menu
    }
    private State _state = State.Playing;

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public State GetState()
    {
        return _state;
    }
}
