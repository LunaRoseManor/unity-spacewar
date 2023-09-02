using UnityEngine;
using TMPro;

public class IncrementTextOnObjectDestroy : MonoBehaviour
{
    [SerializeField]
    private string _gameObjectName;
    private TMP_Text _tmpText;
    private int _count = 0;

    void Awake()
    {
        _tmpText = GetComponent<TMP_Text>();
        InvokeOnDestroy.Event.AddListener(OnGameObjectDestroy);
    }

    private void OnGameObjectDestroy(GameObject check)
    {
        // NOTE: This can fail if someone maliciously names an object the
        //       the exact value as our stored prefab. Ideally this should
        //       check the ID of the exact object we're tracking.
        if (check.name == _gameObjectName)
        {
            // Continue counting
            _count++;
            _tmpText.text = _count.ToString();
        }
    }
}
