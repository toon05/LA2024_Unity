using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 10.0f;
    [SerializeField] private SceneObject titleScene;
    [SerializeField] private SceneObject gameScene;
    [SerializeField] private SceneObject goalScene;

    [SerializeField] private GameObject gameoverPanel;
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        gameoverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            transform.position += new Vector3(playerSpeed * Time.deltaTime, 0, 0);
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += new Vector3(-playerSpeed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(playerSpeed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += new Vector3(0, playerSpeed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += new Vector3(0, -playerSpeed * Time.deltaTime, 0);
            }

            if (transform.position.x >= 50)
            {
                isGameOver = true;
                SceneManager.LoadScene(goalScene);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGameOver = true;
            gameoverPanel.SetActive(true);
        }
    }

    public void OnClickRestartButton()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void OnClickTitleButton()
    {
        SceneManager.LoadScene(titleScene);
    }
}