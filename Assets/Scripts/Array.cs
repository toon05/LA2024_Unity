using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class Array : MonoBehaviour
{
    public GameObject[] prefabs;
    private int[] numbers = new int[]{1, 10, 100};


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            Debug.Log(i + 1);
        }

        Prefabs().Forget();

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = numbers[i] * 2;
        }

        for (int i = 0; i < numbers.Length; i++)
        {
            int sum = 0;
            sum += numbers[i];
            Debug.Log(sum);
        }
    }

    async UniTaskVoid Prefabs()
    {
        
        for (int i = 0; i < prefabs.Length; i++)
        {
            Instantiate(prefabs[i], new Vector3(i * 2.0f, 0, 0), Quaternion.identity);
            await UniTask.Delay(1000);
        }
    }
}
