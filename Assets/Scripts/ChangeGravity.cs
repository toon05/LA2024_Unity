using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGravity : MonoBehaviour 
{
    [SerializeField] private float gravityForce = 9.81f; //重力の強さ
    private Vector3 localGravity;
    private Rigidbody playerRigidbody;
    private bool isReverse = false;

    // Use this for initialization
    private void Start () 
    {
        playerRigidbody = this.GetComponent<Rigidbody>();
        playerRigidbody.useGravity = false; //最初にrigidBodyの重力を使わなくする
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
        SetLocalGravity ( localGravity ); //重力をAddForceでかけるメソッドを呼ぶ。FixedUpdateが好ましい。
    }

    private void SetLocalGravity( Vector3 gravity )
    {
        playerRigidbody.AddForce (gravity, ForceMode.Acceleration);
    }
}