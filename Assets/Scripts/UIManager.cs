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
        if (livesCount > 3)
        {
            _lifeImage.sprite = _lifeSprites[3];
        } else if (livesCount < 0)
        {
            _lifeImage.sprite = _lifeSprites[0];
        } else
        {
            _lifeImage.sprite= _lifeSprites[livesCount];
        }
    }

    public void OnGameOver()
    {
        _gameOverText.gameObject.SetActive(true);
    }
}
