using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControll : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 5.0f;
    private Rigidbody rigidBody;
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += transform.forward * speed;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveDirection += transform.forward * speed; // 速度を2倍にする
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection += -transform.forward * speed;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveDirection += -transform.forward * speed; // 速度を2倍にする
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += -transform.right * speed;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveDirection += -transform.right * speed; // 速度を2倍にする
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += transform.right * speed;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveDirection += transform.right * speed; // 速度を2倍にする
            }
        }

        rigidBody.velocity = new Vector3(moveDirection.x, rigidBody.velocity.y, moveDirection.z);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, jumpForce, rigidBody.velocity.z);
            isGrounded = false;
        }
    }

    // 地面との接触を確認するためのメソッド
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}