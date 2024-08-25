using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retry : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject gameoverPanel;

    public void RetryGame()
    {
        gameoverPanel.SetActive(false);
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }
}