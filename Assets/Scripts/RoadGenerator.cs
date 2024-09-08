using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class RoadGenerator : MonoBehaviour
{
    [SerializeField] private GameObject loadPrefab;
    public int roadNum;
    int roadPositionZ = 0;
    int[] roadPositionY = {8, 10, 12};

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(loadPrefab, new Vector3(0, 10, roadPositionZ), Quaternion.identity);
            Instantiate(loadPrefab, new Vector3(0, -10, roadPositionZ), Quaternion.identity);
            roadPositionZ += 2;
            roadNum++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (roadNum < 40)
        {
            GenerateRoad();
        }
    }

    void GenerateRoad()
    {
        int randomPositionY = RandomPositionY();
        Instantiate(loadPrefab, new Vector3(0, randomPositionY, roadPositionZ), Quaternion.identity);
        randomPositionY = RandomPositionY();
        Instantiate(loadPrefab, new Vector3(0, -randomPositionY, roadPositionZ), Quaternion.identity);
        roadPositionZ += 2;
        roadNum++;
    }

    int RandomPositionY()
    {
        int randomIndex = Random.Range(0, roadPositionY.Length);
        int randomPositionY = roadPositionY[randomIndex];
        return randomPositionY;
    }
}
