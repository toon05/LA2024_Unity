using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHpController : MonoBehaviour
{
    int enemyHp = 3;
    [SerializeField] private GameObject player;
    private Raycaster raycaster;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        raycaster = player.GetComponent<Raycaster>();
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
            raycaster.killCountUp();
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
