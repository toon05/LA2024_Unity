using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PiyoController : MonoBehaviour
{
    int score = 0;
    private Rigidbody playerRigidbody;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private Text gameOverScoreText;

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
        gameOverScoreText.text = "Score: " + score.ToString();
        gameOverUI.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }
}
