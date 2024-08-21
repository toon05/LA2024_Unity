using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private float jumpPower = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == ball)
        {
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }
}
