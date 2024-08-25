using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// コインを回転させるスクリプト
public class CoinController : MonoBehaviour
{
    void Update()
    {
        // コインをY軸で毎秒60の速さで回転させる
        transform.Rotate(Vector3.up, 60 * Time.deltaTime);
    }
}
