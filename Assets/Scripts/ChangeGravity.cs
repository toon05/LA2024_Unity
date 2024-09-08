using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGravity : MonoBehaviour 
{
    [SerializeField] private float gravityForce = 9.81f; //重力の強さ
    private Vector3 localGravity;
    private Rigidbody playerRigidbody;
    private bool isReverse = false;

    [SerializeField] private GameObject GameManager;
    private GameManager gameManager;

    // Use this for initialization
    private void Start () 
    {
        playerRigidbody = this.GetComponent<Rigidbody>();
        playerRigidbody.useGravity = false; //最初にrigidBodyの重力を使わなくする
        gameManager = GameManager.GetComponent<GameManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isReverse = !isReverse;
        }

        if (!isReverse)
        {
            localGravity = new Vector3 (0, -gravityForce, 0); //重力を逆にする
        }
        else
        {
            localGravity = new Vector3 (0, gravityForce, 0); //重力を元に戻す
        }

        // Debug.Log("isReverse: " + isReverse);
    }

    private void FixedUpdate () 
    {
        if (gameManager.isGameOver)
        {
            SetLocalGravity ( new Vector3 (0, 0, 0) );
        }
        else
        {
            SetLocalGravity ( localGravity );
        }
    }

    private void SetLocalGravity( Vector3 gravity )
    {
        playerRigidbody.AddForce (gravity, ForceMode.Acceleration);
    }
}