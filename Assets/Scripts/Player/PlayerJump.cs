using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    // ジャンプの高さ
    public float jumpForce = 7f;

    // 最大ジャンプ回数
    private int maxJumps = 2;

    // 現在のジャンプ回数
    private int currentJumps;

    // Rigidbodyの参照
    private Rigidbody rb;

    // 地面と接触しているかを判定するフラグ
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ResetJumps(); // ゲーム開始時にジャンプ回数を初期化
    }

    private void Update()
    {
        HandleJumpInput();
    }

    // ジャンプ処理
    private void HandleJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentJumps > 0)
        {
            Jump();
        }
    }

    // ジャンプアクション
    private void Jump()
    {
        // Rigidbodyのy軸の速度をリセットしてジャンプ力を加える
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        // ジャンプ回数を減少
        currentJumps--;
    }

    // 地面との接触判定
    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        ResetJumps(); // 地面に触れたらジャンプ回数をリセット
    }

    // ジャンプ回数をリセットするメソッド
    private void ResetJumps()
    {
        currentJumps = maxJumps;
    }
}