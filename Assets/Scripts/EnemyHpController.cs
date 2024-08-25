using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHpController : MonoBehaviour
{
    int enemyHp = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Damage()
    {
        enemyHp--;
        if (enemyHp <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.SendMessage("PlayerDamage");
        }
    }
}
