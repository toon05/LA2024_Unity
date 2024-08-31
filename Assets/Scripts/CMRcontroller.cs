using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMRcontroller : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    [SerializeField] private GameObject playerObj;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = playerObj.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerController.isGameClear)
        {
            this.transform.position = player.position + offset;
            Debug.Log("Game Clear");
        }
    }
}
