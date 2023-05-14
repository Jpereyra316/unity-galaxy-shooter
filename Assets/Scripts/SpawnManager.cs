using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy;

    [SerializeField]
    private GameObject[] _powerUps;

    [SerializeField]
    private GameObject _enemyContainer;

    private bool _continueSpawning = true;

    const float TOP_OF_SCREEN = 7f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-8f, 8f), TOP_OF_SCREEN);
        while (_continueSpawning)
        {
            Instantiate(_enemy, spawnPos, Quaternion.identity, _enemyContainer.transform);
            yield return new WaitForSeconds(Random.Range(1f, 5f));
        }
    }

    IEnumerator SpawnPowerupRoutine()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-8f, 8f), TOP_OF_SCREEN);
        while (_continueSpawning)
        {
            int randomPowerUp = Random.Range(((int)Powerup.PowerUpType.FIRST), ((int)Powerup.PowerUpType.LAST));
            Instantiate(_powerUps[randomPowerUp], spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(7f, 10f));
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
    }

    public void OnLevelRestart()
    {
        _continueSpawning = true;
    }
}
