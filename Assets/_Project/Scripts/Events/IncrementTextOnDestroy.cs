using UnityEngine;

public class IncrementTextOnDestroy : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameObject;
    private TextMesh _textMesh;
    private int _count = 0;

    void Awake()
    {
        _textMesh = GetComponent<TextMesh>();
        InvokeOnDestroy.Event.AddListener(OnGameObjectDestroy);
    }

    private void OnGameObjectDestroy(GameObject check)
    {
        // NOTE: This can fail if someone maliciously names an object the
        //       the exact value as our stored prefab. Ideally this should
        //       check the ID of the exact object we're tracking.
        if (check.name == _gameObject.name)
        {
            // Continue counting
            _count++;
            _textMesh.text = _count.ToString();
        }
    }
}
