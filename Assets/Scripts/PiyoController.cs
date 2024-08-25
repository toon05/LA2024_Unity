using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiyoController : MonoBehaviour
{
    int score = 0;
    private Rigidbody playerRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            playerRigidbody.velocity = new Vector3(0, 6, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Game Over");
    }

    private void OnTriggerEnter(Collider other)
    {
        score++;
        Debug.Log("Score: " + score);
    }
}
