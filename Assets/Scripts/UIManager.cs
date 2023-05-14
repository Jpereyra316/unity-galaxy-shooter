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

    [SerializeField]
    private Text _restartLevelText;

    private bool _gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore(0);
        _gameOverText.gameObject.SetActive(false);
        _restartLevelText.gameObject.SetActive(false);
    }

    public void UpdateScore(int newScore)
    {
        _scoreText.text = "Score: " + newScore.ToString();
    }

    public void UpdateLives(int livesCount)
    {
        _lifeImage.sprite = _lifeSprites[livesCount];

        _gameOver = (livesCount == 0);

        if (_gameOver)
        {
            StartCoroutine(GameOverRoutine());
        }
    }

    IEnumerator GameOverRoutine()
    {
        while (_gameOver)
        {
            yield return new WaitForSeconds(0.5f);
            _gameOverText.gameObject.SetActive(!_gameOverText.gameObject.activeSelf);
            _restartLevelText.gameObject.SetActive(!_restartLevelText.gameObject.activeSelf);
        }
    }
}
