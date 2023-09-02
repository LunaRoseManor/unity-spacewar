using TMPro;
using UnityEngine;

public class ChangeTextOnAwake : MonoBehaviour
{
    [SerializeField]
    private string _text = string.Empty;
    private TextMeshProUGUI _textMeshProUGUI;

    private void Awake()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        _textMeshProUGUI.text = _text;
    }
}
