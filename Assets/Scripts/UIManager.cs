using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;

    [SerializeField]
    private Image _lifeImage;

    [SerializeField]
    private Sprite[] _lifeSprites;

    [SerializeField]
    private Text _gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore(0);
        _gameOverText.gameObject.SetActive(false);
    }

    public void UpdateScore(int newScore)
    {
        _scoreText.text = "Score: " + newScore.ToString();
    }

    public void UpdateLives(int livesCount)
    {
        _lifeImage.sprite = _lifeSprites[livesCount];

        if (livesCount == 0)
        {
            _gameOverText.gameObject.SetActive(true);
        }
    }
}
