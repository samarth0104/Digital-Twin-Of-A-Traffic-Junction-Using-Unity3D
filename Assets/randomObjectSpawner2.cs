using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RandomObjectSpawner2 : MonoBehaviour
{
    public GameObject[] myObjects;
    private string spawnCountFilePath; // Path to the text file
    private string totalTimeFilePath; // Path to the total time file

    void Start()
    {
        spawnCountFilePath = Application.dataPath + "/spawn_count2.txt"; // Path to the text file
        totalTimeFilePath = Application.dataPath + "/totaltime.txt"; // Path to the total time file
        StartCoroutine(SpawnObjectsRepeatedly());
    }

    IEnumerator SpawnObjectsRepeatedly()
    {
        while (true)
        {
            // Read the spawn count from the text file
            int spawnCount = ReadSpawnCountFromFile(spawnCountFilePath);

            // Spawn the specified number of objects
            for (int i = 0; i < spawnCount; i++)
            {
                // Spawn a random object
                int randomIndex = Random.Range(0, myObjects.Length);
                Vector3 randomSpawnPosition = new Vector3(-65.4f, 0.78f, 9.7f);
                Instantiate(myObjects[randomIndex], randomSpawnPosition, Quaternion.identity);
            }

            // Read the total time from the file
            float totalTime = ReadTotalTimeFromFile(totalTimeFilePath);

            // Wait for the specified time before spawning again
            yield return new WaitForSeconds(totalTime);
        }
    }

    // Read the content of the spawn count text file
    int ReadSpawnCountFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            string content = File.ReadAllText(filePath);
            int spawnCount;
            if (int.TryParse(content, out spawnCount))
            {
                return spawnCount;
            }
            else
            {
                Debug.LogError("Failed to parse spawn count from file.");
                return 0;
            }
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
            return 0;
        }
    }

    // Read the content of the total time text file
    float ReadTotalTimeFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            string content = File.ReadAllText(filePath);
            float totalTime;
            if (float.TryParse(content, out totalTime))
            {
                return totalTime;
            }
            else
            {
                Debug.LogError("Failed to parse total time from file.");
                return 0;
            }
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
            return 0;
        }
    }
}