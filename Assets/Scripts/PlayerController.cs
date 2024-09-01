using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 10.0f;
    float x;
    float y;
    Rigidbody playerRigidbody;

    [SerializeField] private SceneObject titleScene;
    [SerializeField] private SceneObject [] stages;

    [SerializeField] private GameObject goalPanel;
    [SerializeField] private GameObject gameoverPanel;
    private bool isGameOver = false;
    public bool isGameClear = false;
    public bool isRotate = false;
    bool isEchoed = false;

    // Start is called before the first frame update
    void Start()
    {
        gameoverPanel.SetActive(false);
        goalPanel.SetActive(false);
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            transform.position += new Vector3(playerSpeed * Time.deltaTime, 0, 0);

            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");

            playerRigidbody.velocity += new Vector3(0, y, -x);

            transform.rotation = Quaternion.AngleAxis(x * -30, Vector3.right);


            if (transform.position.x >= 50)
            {
                isGameOver = true;
                isGameClear = true;
                goalPanel.SetActive(true);
            }
        }

        if (isGameClear)
        {
            transform.position += new Vector3(playerSpeed * Time.deltaTime, 0, 0);
        }

        if (isRotate)
        {
            if (!isEchoed && this.transform.position.x >= -10)
            {
                isEchoed = true;
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

    public void OnClickRestartButton(int index)
    {
        SceneManager.LoadScene(stages[index]);
    }

    public void OnClickTitleButton()
    {
        SceneManager.LoadScene(titleScene);
    }
}