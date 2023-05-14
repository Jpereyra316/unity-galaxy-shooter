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

    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore(0);
        NewMethod();
        _restartLevelText.gameObject.SetActive(false);

        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        if (_gameManager == null)
        {
            Debug.LogError("Game Manager is null!");
        }
    }

    private void NewMethod()
    {
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
            GameOver();
        }
    }

    void GameOver()
    {
        _restartLevelText.gameObject.SetActive(true);
        StartCoroutine(GameOverRoutine());
        _gameManager.GameOver();
    }

    IEnumerator GameOverRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            _gameOverText.gameObject.SetActive(!_gameOverText.gameObject.activeSelf);
        }
    }
}
