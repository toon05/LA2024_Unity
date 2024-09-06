using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCreator : MonoBehaviour
{
    public GameObject[] wallPrefabs;
    int wallNum;

    float timer = 0;
    int interval = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            transform.position = new Vector3(0, Random.Range(-1.0f, 2.0f), 6);

            wallNum = Random.Range(0, wallPrefabs.Length);
            Instantiate(wallPrefabs[wallNum], transform.position, transform.rotation);
            timer = 0;
        }
    }
}
