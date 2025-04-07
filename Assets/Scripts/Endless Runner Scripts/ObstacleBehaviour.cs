using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    private GameManager_Endless _gameManager;
    private SpawnerScript _spawnerScript;

    void Awake()
    {
        _gameManager = FindObjectOfType<GameManager_Endless>();
        if (_gameManager == null)
        {
            Debug.LogError("GameManager Script is Null!");
        }
        
        _spawnerScript = FindObjectOfType<SpawnerScript>();
        if (_spawnerScript == null)
        {
            Debug.LogError("SpawnerScript is Null!");
        }
    }
    void Update()
    {

        if (_gameManager == null)
        {
            return;
        }

        Vector3 moveToLeft = Vector3.left * _gameManager.AdjustedSpeed() * Time.deltaTime;
        transform.Translate(moveToLeft);
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }

        if(col.gameObject.CompareTag("Player"))
        {
            if (_spawnerScript == null)
            {
                return;
            }
            _spawnerScript.isGameOver();
            _gameManager.endGame(1);
            Destroy(gameObject);

        }
    }
}
