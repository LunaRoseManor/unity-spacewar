using TMPro;
using UnityEngine;

public class ChangeTextBasedOnPlayerScore : MonoBehaviour
{
    [SerializeField]
    private int player = 1;
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        switch (player)
        {
            case 1:
                _text.text = Game.Instance.PlayerOneScore.ToString();
                break;
            case 2:
                _text.text = Game.Instance.PlayerTwoScore.ToString();
                break;
        }
    }
}
