using System.Collections;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject[] _ObstacleOBJ;
    [SerializeField] private float _spawnDelay = 3f;
    [SerializeField] private float _afterSpawnOffset = 2f;
    [SerializeField] private bool _stopSpawning = false;


    private GameManager_Endless _gameManager;

    void Awake()
    {
        _gameManager = FindObjectOfType<GameManager_Endless>();
        if (_gameManager == null)
        {
            Debug.LogError("GameManager Script is Null!");
        }
    }

    void Start()
    {

        StartCoroutine(SpawnObstacle());
    }


    IEnumerator SpawnObstacle()
    {
        yield return new WaitForSeconds(_spawnDelay);
        Instantiate(_ObstacleOBJ[0], transform.position, Quaternion.identity);

        yield return new WaitForSeconds((_spawnDelay / 2) + _afterSpawnOffset);

        while (!_stopSpawning)
        {
            int randObstacle = Random.Range(0, 2);

            Instantiate(_ObstacleOBJ[randObstacle], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(4f, 9f));
        }
    }
    public void isGameOver()
    {
        _stopSpawning = true;
    }
}
