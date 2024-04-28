using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class WallController : MonoBehaviour
{
    public GameObject[] walls; // Array of wall GameObjects to control
    public float routineInterval = 40.0f; // Default interval for running the control routine

    private string filePath; // Path to the CSV file
    private List<KeyValuePair<string, int>> sortedLaneData = new List<KeyValuePair<string, int>>(); // Sorted list of lane data

    void Start()
    {
        filePath = Application.dataPath + "/lane.csv"; // Path to the CSV file
        StartCoroutine(ControlWallsRoutine());
    }

    IEnumerator ControlWallsRoutine()
    {
        while (true)
        {
            // Read and parse the CSV file
            ReadCSVFile(filePath);

            // Calculate the maximum wait time from the number of cars in all lanes
            float maxWaitTime = CalculateMaxWaitTime();

            // Set the routine interval to the maximum wait time
            routineInterval = maxWaitTime-15.0f;

            // Sort the lane data by the number of cars in descending order
            sortedLaneData = sortedLaneData.OrderByDescending(x => x.Value).ToList();

            // Iterate through the sorted lane data and toggle the walls accordingly
            foreach (var entry in sortedLaneData)
            {
                // Get the index of the wall corresponding to the lane name
                int wallIndex = int.Parse(entry.Key.Substring(entry.Key.Length - 1)) - 1; // Assuming the wall names end with numbers (e.g., "Signal1", "Signal2")

                // Determine the signal duration based on the number of cars in the lane
                float signalDuration = CalculateSignalDuration(entry.Value);

                // Close the wall for the calculated duration
                CloseWall(walls[wallIndex]);

                // Wait for the signal duration
                yield return new WaitForSeconds(signalDuration);

                // Open the wall after the signal duration
                OpenWall(walls[wallIndex]);
            }

            // Wait for the routine interval before running again
            yield return new WaitForSeconds(routineInterval);
        }
    }

    void ReadCSVFile(string filePath)
    {
        sortedLaneData.Clear(); // Clear previous data
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            // Skip the header line (assuming it contains column names)
            for (int i = 1; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');
                string lane = data[0].Trim();
                int carCount = int.Parse(data[1].Trim());
                sortedLaneData.Add(new KeyValuePair<string, int>(lane, carCount));
            }
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
        }
    }

    void OpenWall(GameObject wall)
    {
        // Activate the wall
        wall.SetActive(true);
    }

    void CloseWall(GameObject wall)
    {
        // Deactivate the wall
        wall.SetActive(false);
    }

    float CalculateSignalDuration(int carCount)
    {
        // Calculate the signal duration based on the number of cars in the lane
        if (carCount > 10)
        {
            return 20.0f;
        }
        else if (carCount >= 5 && carCount <= 10)
        {
            return 15.0f;
        }
        else
        {
            return 10.0f;
        }
    }

    float CalculateMaxWaitTime()
    {
        // Calculate the maximum wait time from the number of cars in all lanes
        int maxCarCount = sortedLaneData.Max(x => x.Value);
        return CalculateSignalDuration(maxCarCount);
    }
}
