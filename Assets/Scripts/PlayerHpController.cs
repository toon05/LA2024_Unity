using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHpController : MonoBehaviour
{
    int playerHp = 1;
    [SerializeField] private GameObject gameoverPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayerDamage()
    {
        playerHp--;
        if (playerHp <= 0)
        {
            gameoverPanel.SetActive(true);
            // Destroy(gameObject);
        }
    }
}