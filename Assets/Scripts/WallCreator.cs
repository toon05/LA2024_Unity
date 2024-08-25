using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCreator : MonoBehaviour
{
    [SerializeField] private GameObject wall;
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
            Instantiate(wall, transform.position, Quaternion.identity);
            timer = 0;
        }
    }
}
