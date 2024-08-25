using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Playerの移動速度
    public float moveSpeed = 7.0f;
    // 獲得したコインの数を保持する変数
    private int coinCount = 0;
    // クリアした時に表示するテキスト
    public GameObject clearText;

    void Update()
    {
        // 上キーを入力すると前に移動
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, moveSpeed * Time.deltaTime);
        }
        // 下キーを入力すると後ろに移動
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -moveSpeed * Time.deltaTime);
        }
        // 左キーを入力すると左に移動
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
        }
        // 右キーを入力すると右に移動
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }
    }

    // 接地したかを判定する関数
    public void OnTriggerEnter(Collider other)
    {
        // タグが"Coin"かどうかを判定する
        if (other.gameObject.CompareTag("Coin"))
        {
            // コインを獲得した時にCoinCountの値を1増加させる
            coinCount++;
            // コインのゲームオブジェクトを削除する
            Destroy(other.gameObject);

            // コインを獲得してクリアを判定する
            if (coinCount >= 7)
            {
                // クリアテキストを表示する
                clearText.SetActive(true);
            }
        }
    }
}
