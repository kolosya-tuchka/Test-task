using System;
using TMPro;
using UnityEngine;

public class GemsScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    public void UpdateScoreText(int amount)
    {
        _scoreText.text = amount.ToString();
    }
}
