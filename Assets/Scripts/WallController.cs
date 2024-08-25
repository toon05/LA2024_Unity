using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    float speed = 2;
    float delayUntilDestroyed = 10;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, delayUntilDestroyed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.forward * speed * Time.deltaTime;
    }
}
