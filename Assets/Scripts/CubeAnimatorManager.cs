using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAnimatorManager : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isRotate", true);
            Debug.Log("Space key was pressed.");
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("isRotate", false);
            Debug.Log("Space key was released.");
        }
    }
}