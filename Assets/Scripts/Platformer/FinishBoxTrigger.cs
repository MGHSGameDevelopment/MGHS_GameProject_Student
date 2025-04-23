using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishBoxTrigger : MonoBehaviour
{
    [SerializeField] private GameObject victoryPanelBoard; // Assign in Unity Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the player enters the trigger
        {
            victoryPanelBoard.SetActive(true); // Show the VictoryPanelBoard
            Debug.Log("Player entered the finish box!");
        }
    }
}

