using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public int count = 0;
    [SerializeField] private GameObject countTextObj;
    private Text countText;
    private bool flg = false;

    // Start is called before the first frame update
    void Start()
    {
        countText = countTextObj.GetComponent<Text>();
        countText.text = count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (flg)
        {
            OnClickPlus();
        }
    }

    public void OnClickPlus()
    {
        count++;
        countText.text = count.ToString();
    }

    public void OnClickMinus()
    {
        count--;
        countText.text = count.ToString();
    }

    public void OnClickReset()
    {
        count = 0;
        countText.text = count.ToString();
    }

    public void ChangeFlg()
    {
        flg = !flg;
        Debug.Log(flg);
    }
}
