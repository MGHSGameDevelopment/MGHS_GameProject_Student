using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachedGoal : MonoBehaviour
{
    public float goalX = 10f;

    // Method to check if player has reached the goal
    public bool HasReachedGoal()
    {
        return transform.position.x >= goalX;
    }
}
