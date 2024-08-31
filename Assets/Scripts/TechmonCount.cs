using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TechmonCount : MonoBehaviour
{
    public int number = 0;
    public Text powerText;
    public Text damageText;
    int total;
    public AudioSource audioSource;
    public AudioClip attackSound;
    public GameObject clearPanel;
    bool isCharge = false;

    // Start is called before the first frame update
    void Start()
    {
        clearPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isCharge)
        {
            CountUp();
        }
    }

    public void CountUp()
    {
        number++;
        powerText.text = number.ToString();
    }

    public void Attack()
    {
        total += number;
        damageText.text = total.ToString();
        audioSource.PlayOneShot(attackSound);
        number = 0;
        if (total >= 100)
        {
            clearPanel.SetActive(true);
        }
    }

    public void ButtonUp()
    {
        if (!isCharge)
        {
            return;
        }
        isCharge = false;
    }

    public void ButtonDown()
    {
        if (isCharge)
        {
            return;
        }
        isCharge = true;
    }
}
