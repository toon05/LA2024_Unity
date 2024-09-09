using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeCycleManager : MonoBehaviour
{
    private const float RespawnHeight = -2f;

    [SerializeField] private GameObject playerModel;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private void Start()
    {
        initialPosition = transform.position;
        initialRotation = playerModel.transform.rotation;
    }

    private void Update()
    {
        if (transform.position.y < RespawnHeight)
        {
            Respawn();
        }
    }
    
    public void Respawn()
    {
        transform.position = initialPosition;
        playerModel.transform.rotation = initialRotation;
    }
}
