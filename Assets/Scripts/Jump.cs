using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private float jumpForce = 10f;
    private Rigidbody rb;
    private bool isGrounded = false;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject target;
    private Renderer playerRenderer;
    private Renderer targetRenderer;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        playerRenderer = player.GetComponent<Renderer>();
        targetRenderer = target.GetComponent<Renderer>();
        RandomColor(playerRenderer);
        RandomColor(targetRenderer);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // ジャンプはY軸方向に力を加える
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isGrounded = false; // ジャンプしたら空中状態にする
        }
    }

    void RandomColor(Renderer renderer)
    {
        renderer.material.color = new Color(Random.value, Random.value, Random.value, 1.0f);
    }

    // 地面に着いたらisGroundedをtrueにする
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Target"))
        {
            playerRenderer.material.color = targetRenderer.material.color;
            RandomColor(targetRenderer);
        }
    }
}