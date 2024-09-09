using UnityEngine;

public class PlayerJetpack : MonoBehaviour
{
    // 飛行速度
    public float flightSpeed = 5f;

    // 最大飛行時間
    public float maxFlightTime = 5f;

    // 現在の飛行時間
    private float currentFlightTime;

    // パーティクルの参照
    public GameObject jetpackParticle; // 事前にアタッチされたパーティクルを使う

    // 飛行中かどうか
    private bool isFlying = false;

    // Rigidbodyの参照
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ResetFlightTime(); // 飛行時間を初期化
        jetpackParticle.SetActive(false); // 初期状態ではパーティクルは非アクティブ
    }

    private void Update()
    {
        HandleFlightInput();
    }

    // 飛行の入力処理
    private void HandleFlightInput()
    {
        if (Input.GetKey(KeyCode.Space) && currentFlightTime > 0)
        {
            StartFlying();
        }
        else
        {
            StopFlying();
        }
    }

    // 飛行を開始
    private void StartFlying()
    {
        if (!isFlying)
        {
            isFlying = true;

            // パーティクルをアクティブ化
            jetpackParticle.SetActive(true);
        }

        // プレイヤーを上昇させる
        rb.velocity = new Vector3(rb.velocity.x, flightSpeed, rb.velocity.z);

        // 飛行時間を減らす
        currentFlightTime -= Time.deltaTime;
        currentFlightTime = Mathf.Clamp(currentFlightTime, 0, maxFlightTime);
    }

    // 飛行を停止
    private void StopFlying()
    {
        if (isFlying)
        {
            isFlying = false;

            // パーティクルを非アクティブ化
            jetpackParticle.SetActive(false);
        }
    }

    // 地面との接触判定
    private void OnCollisionEnter(Collision collision)
    {
        ResetFlightTime(); // 地面に触れたら飛行時間をリセット
    }

    // 飛行時間をリセットするメソッド
    private void ResetFlightTime()
    {
        currentFlightTime = maxFlightTime;
    }
}