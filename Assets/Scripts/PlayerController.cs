using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    private Rigidbody playerRigidbody;

    [SerializeField] private GameObject GameManager;
    private GameManager gameManager;

    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private Text HighScoreText;
    [SerializeField] private Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = this.GetComponent<Rigidbody>();
        gameManager = GameManager.GetComponent<GameManager>();
        GameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(gameManager.isGameOver);
    }

    void MovePlayer(bool isGameOver)
    {
        if (isGameOver)
        {
            playerRigidbody.velocity = Vector3.zero;
        }
        else
        {
            Vector3 velocity = playerRigidbody.velocity;
            velocity.z = moveSpeed;
            playerRigidbody.velocity = velocity;
        }
    }

    void GameOver()
    {
        gameManager.isGameOver = true;

        if (PlayerPrefs.GetInt("HighScore", 0) < gameManager.score)
        {
            PlayerPrefs.SetInt("HighScore", gameManager.score);
        }

        HighScoreText.text = "HighScore: " + PlayerPrefs.GetInt("HighScore", 0);
        ScoreText.text = "Score: " + gameManager.score;
        GameOverPanel.SetActive(true);
        Debug.Log("GameOver");
    }

    void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトがCubeであるか確認
        if (collision.gameObject.CompareTag("Cube"))
        {
            // Cubeの上端と下端の座標を取得
            Vector3 topPosition = GetTopPosition(collision.transform);
            Vector3 bottomPosition = GetBottomPosition(collision.transform);
            
            if (Mathf.Abs(topPosition.y) - Mathf.Abs(transform.position.y) <= 0)
            {
                foreach (ContactPoint contact in collision.contacts)
                {
                    // Y軸の法線を無視（上や下の面の衝突）
                    if (Mathf.Abs(contact.normal.y) < 0.1f)
                    {
                        // 側面での衝突が検知された場合の処理
                        // Debug.Log("Cubeの側面に衝突しました！");
                        GameOver();
                    }
                }
            }

            if (Mathf.Abs(bottomPosition.y) - Mathf.Abs(transform.position.y) <= 0)
            {
                foreach (ContactPoint contact in collision.contacts)
                {
                    // Y軸の法線を無視（上や下の面の衝突）
                    if (Mathf.Abs(contact.normal.y) < 0.1f)
                    {
                        // 側面での衝突が検知された場合の処理
                        // Debug.Log("Cubeの側面に衝突しました！");
                        GameOver();
                    }
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            gameManager.score += 10;
            other.gameObject.SetActive(false);
        }
    }

    // Cubeの上端の座標を取得するメソッド
    Vector3 GetTopPosition(Transform cubeTransform)
    {
        // Cubeの中心座標
        Vector3 cubeCenter = cubeTransform.position;
        
        // Cubeのローカルスケール（サイズ）
        float cubeHeight = cubeTransform.localScale.y;
        
        // 上端のY座標は中心からスケールの半分だけ上に移動
        Vector3 topPosition = cubeCenter + new Vector3(0, cubeHeight / 2, 0);
        
        return topPosition;
    }

    // Cubeの下端の座標を取得するメソッド
    Vector3 GetBottomPosition(Transform cubeTransform)
    {
        // Cubeの中心座標
        Vector3 cubeCenter = cubeTransform.position;
        
        // Cubeのローカルスケール（サイズ）
        float cubeHeight = cubeTransform.localScale.y;
        
        // 下端のY座標は中心からスケールの半分だけ下に移動
        Vector3 bottomPosition = cubeCenter - new Vector3(0, cubeHeight / 2, 0);
        
        return bottomPosition;
    }
}