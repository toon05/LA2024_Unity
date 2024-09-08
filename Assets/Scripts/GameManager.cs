using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public bool isGameOver = false;

    [SerializeField] private Text scoreText;

    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score = (int)(player.transform.position.z / 5);
        scoreText.text = "Score: " + score;
    }

    public void OnClickRetryButton()
    {
        SceneManager.LoadScene("GravitySwitch");
    }
}
