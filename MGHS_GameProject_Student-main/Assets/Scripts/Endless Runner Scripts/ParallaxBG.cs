using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG : MonoBehaviour
{

    private float _distance;
    private Material _mat;

    [Range(0f,2f)]
    [SerializeField] float _defaultScrollSpeed;
    [SerializeField] private float _speedMultiplier = 0.5f;
    private float _runtimeScrollspeed;
    void Awake()
    {
        _mat = GetComponent<Renderer>().material;
    }

    void Start()
    {
        ResetSpeed(); // Ensures the speed is reset when the game starts
    }

    void Update()
    {
        if (Time.timeScale == 0f) return;
        _distance += _runtimeScrollspeed * Time.deltaTime;
        _mat.SetTextureOffset("_MainTex", Vector2.right * _distance);
        Debug.Log("Current Scroll Speed is: " + _runtimeScrollspeed);
    }
    public void SetSpeed(float newSpeed)
    {
        _runtimeScrollspeed = newSpeed; // Directly set new speed
    }

    public float GetDefaultSpeed()
    {
        return _defaultScrollSpeed;
    }
    public float GetSpeed()
    {
        return _runtimeScrollspeed; // Retrieve the current speed
    }   

    public float GetSpeedMultiplier()
    {
        return _speedMultiplier; // Allows GameManager to access this value
    }

    public void ResetSpeed()
    {
        _runtimeScrollspeed = _defaultScrollSpeed;
    }
}
    