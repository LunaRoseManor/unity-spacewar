using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnAwake : MonoBehaviour
{
    [SerializeField]
    private Object _scene;

    void Awake()
    {
        SceneManager.LoadScene(_scene.name);
    }
}
