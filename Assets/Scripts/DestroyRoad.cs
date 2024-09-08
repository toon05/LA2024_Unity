using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRoad : MonoBehaviour
{
    [SerializeField] private GameObject roadGenerator;
    private RoadGenerator roadGeneratorScript;

    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        roadGeneratorScript = roadGenerator.GetComponent<RoadGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnBecameInvisible()
    {
        if (player.transform.position.z > this.transform.position.z)
        {
            Destroy(this.gameObject);
            roadGeneratorScript.roadNum--;
        }
    }
}
