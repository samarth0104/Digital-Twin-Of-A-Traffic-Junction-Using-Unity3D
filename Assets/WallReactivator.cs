using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallReactivator : MonoBehaviour
{
    public List<GameObject> walls; // List of wall GameObjects to reactivate

    void Update()
    {
        // Iterate through the list of walls
        foreach (GameObject wall in walls)
        {
            // Check if the wall is currently inactive
            if (!wall.activeSelf)
            {
                // Reactivate the wall
                wall.SetActive(true);
            }
        }
    }
}
