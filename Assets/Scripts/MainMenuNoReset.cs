using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuNoReset : MonoBehaviour
{
    void Awake()
{
    
    DontDestroyOnLoad(gameObject);  
    
}
}
