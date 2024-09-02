using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int score = 0;
    Rigidbody playerRigidbody;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            playerRigidbody.velocity = new Vector3(0, 6, 0);
            audioSource.Play();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Game Over");
    }

    void OnTriggerEnter(Collider other)
    {
        score++;
        Debug.Log("Score: " + score);
    }
}
