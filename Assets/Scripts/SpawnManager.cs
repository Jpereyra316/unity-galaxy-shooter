using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy;

    [SerializeField]
    private GameObject _life;

    [SerializeField]
    private GameObject _enemyContainer;

    [SerializeField]
    private GameObject _lifeContainer;

    private bool _continueSpawning = true;

    const float TOP_OF_SCREEN = 7f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-8f, 8f), TOP_OF_SCREEN);
        while (_continueSpawning)
        {
            if(Random.Range(0,6) == 1)
            {
                Instantiate(_life, spawnPos, Quaternion.identity, _lifeContainer.transform);
            } else
            {
                Instantiate(_enemy, spawnPos, Quaternion.identity, _enemyContainer.transform);
            }
            yield return new WaitForSeconds(Random.Range(1f, 5f));
        }
    }

    public void OnPlayerDeath()
    {
        _continueSpawning = false;

        // Clean up the remaining enemies
        Enemy[] enemies = _enemyContainer.GetComponentsInChildren<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }

        // Clean up the remaining lives
        Life[] lives = _enemyContainer.GetComponentsInChildren<Life>();
        foreach (Life life in lives)
        {
            Destroy(life.gameObject);
        }
    }
}
