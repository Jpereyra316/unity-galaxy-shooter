using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _gameOver = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && _gameOver)
        {
            _gameOver = false;
            SceneManager.LoadScene(1); // Current game scene
        }
    }

    public void GameOver()
    {
        _gameOver = true;
    }
}
