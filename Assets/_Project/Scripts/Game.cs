using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game Instance;
    public static SceneManager SceneManager;
    // TODO: actually make this not global
    public int PlayerOneScore = 0;
    public int PlayerTwoScore = 0;

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
        InvokeOnDestroy.Event.AddListener(OnGameObjectDestroy);
    }

    void Update()
    {
        if (PlayerOneScore >= 10 || PlayerOneScore >= 10)
        {
            SceneManager.LoadScene("Results");
        }
    }

    public State GetState()
    {
        return _state;
    }

    private void OnGameObjectDestroy(GameObject gameObject)
    {
        // This code is such an abomination but I'm running close to
        // the deadline and there's nothing I could do
        if (gameObject.name == "Needle(Clone)")
        {
            // It's reversed because you shouldn't be rewarded for
            // destroying yourself
            PlayerTwoScore++;
        }
        else if (gameObject.name == "Wedge(Clone)")
        {
            PlayerOneScore++;
        }
    }
}
