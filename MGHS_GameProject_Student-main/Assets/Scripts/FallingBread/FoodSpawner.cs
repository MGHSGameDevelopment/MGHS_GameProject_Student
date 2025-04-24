using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] FoodPrefabs;
    [SerializeField] private GameObject Food;
    GameObject _food;
    public Fb_GameManager _FBManager;
    [SerializeField] private Transform[] SpawnPos;
    public float foodRate = 3f;
    public bool isReady;
    public int DifficultyTimer = 0;
    void Start()
    {
        isReady = false;
        DifficultyTimer = 0;
        Food.GetComponent<Rigidbody2D>();
        Food.GetComponent<Rigidbody2D>().gravityScale = 0.08f;
        _FBManager.GetComponent<Fb_GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isReady)
        {
            isReady = true;
            StartCoroutine(StartTimeDecay());
            StartCoroutine(Fb_FoodSpawn());
            StartCoroutine(IngameTimeCount());
        }
        // >15f for testing, 45f for actual gameplay
        /*if (Time.time > 45f &&isReady)
        {
            Debug.Log("Hard");
            foodRate = 1.5f;
            Food.GetComponent<Rigidbody2D>().gravityScale = 0.20f;
        }*/
    }

    IEnumerator Fb_FoodSpawn()
    {
        while(isReady)
        {
            Transform _spawnFoodPos = SpawnPos[Random.Range(0, SpawnPos.Length)];
            _food = Instantiate(FoodPrefabs[Random.Range(0,FoodPrefabs.Length)], _spawnFoodPos.position, Quaternion.identity);

            if (DifficultyTimer > 45f && isReady)
            {
                Debug.Log("Hard");
                foodRate = 1.5f;
                _food.GetComponent<Rigidbody2D>().gravityScale = 0.20f;
            }
            else
            {
                foodRate = 3.0f;
                _food.GetComponent<Rigidbody2D>().gravityScale = 0.08f;
            }
            yield return new WaitForSeconds(foodRate);
        }
    }

    IEnumerator StartTimeDecay()
    {
        while (isReady)
        {
            _FBManager.TimeDecay();
            yield return new WaitForSeconds(1f);
        }

    }

    IEnumerator IngameTimeCount()
    {
        while (isReady)
        {
            DifficultyTimer++;
            yield return new WaitForSeconds(1f);
        }
    }

    public void FbUI_BeginMinigame()
    {
        _FBManager.isReady = true;
        isReady = true;
    }
}
