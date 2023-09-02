using UnityEngine;
using TMPro;

public class ResultsScoreText : MonoBehaviour
{
    TMP_Text _tmpText;

    void Awake()
    {
        _tmpText = GetComponent<TMP_Text>();

        if (Game.Instance.PlayerOneScore > Game.Instance.PlayerTwoScore)
        {
            _tmpText.text = "Player One Wins!";
        }
        else
        {
            _tmpText.text = "Player Two Wins";
        }
    }
}
