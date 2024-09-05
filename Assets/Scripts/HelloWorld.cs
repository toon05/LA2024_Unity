using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class HelloWorld : MonoBehaviour
{
    string[] message;
    int age = 15;
    int mentorAge = 22;

    // Start is called before the first frame update
    void Start()
    {
        // 配列を正しい形式で初期化
        message = new string[] { "Hello", "World", "Life", "is", "Tech!" , (age + mentorAge).ToString()};

        // 非同期メソッドの呼び出し
        LogMessage().Forget();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    async UniTask LogMessage()
    {
        foreach (var m in message)
        {
            Debug.Log(m);
            await UniTask.Delay(1000); // 1秒間待機
        }
    }
}