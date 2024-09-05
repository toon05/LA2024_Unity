using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHpController : MonoBehaviour
{
    int playerHp = 3;
    [SerializeField] Text hpText;
    private string gameOverScene = "GameOver";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = "HP: " + playerHp;
    }

    void PlayerDamage()
    {
        playerHp--;
        if (playerHp <= 0)
        {
            SceneManager.LoadScene(gameOverScene);
        }
    }
}