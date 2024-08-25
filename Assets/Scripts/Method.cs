using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Method : MonoBehaviour
{
    [SerializeField] private InputField inputField1;
    [SerializeField] private InputField inputField2;
    [SerializeField] private Text resultText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int CalculateSum(int a, int b)
    {
        int sum = a + b;
        return sum;
    }

    public void OnButtonClick()
    {
        int a = int.Parse(inputField1.text);
        int b = int.Parse(inputField2.text);
        int sum = CalculateSum(a, b);
        resultText.text = sum.ToString();
    }
}
