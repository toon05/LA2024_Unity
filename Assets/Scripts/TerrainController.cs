using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainController : MonoBehaviour
{
    public GameObject[] terrain;
    float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < terrain.Length; i++)
        {
            terrain[i].transform.position += new Vector3(0, 0, -speed * Time.deltaTime);
        }

        if (terrain[0].transform.position.z < -600)
        {
            terrain[0].transform.position = new Vector3(-150, -20, 900);
        }
        else if (terrain[1].transform.position.z < -600)
        {
            terrain[1].transform.position = new Vector3(-150, -20, 900);
        }
    }
}
