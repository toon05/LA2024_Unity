using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCreator : MonoBehaviour
{
    [SerializeField] private GameObject[] walls;
    int wallNumber;
    float timer = 0;
    int interval = 2;

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
            transform.position = new Vector3(0, Random.Range(-1, 2), 6);

            wallNumber = Random.Range(0, walls.Length);
            Instantiate(walls[wallNumber], transform.position, transform.rotation);
            timer = 0;
        }
    }
}
