using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy;

    [SerializeField]
    private GameObject _enemyContainer;

    private bool _continueSpawning = true;

    const float TOP_OF_SCREEN = 7f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (_continueSpawning)
        {
            Instantiate(_enemy, new Vector3(Random.Range(-8f, 8f), TOP_OF_SCREEN), Quaternion.identity, _enemyContainer.transform);
            yield return new WaitForSeconds(5.0f);
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
}
