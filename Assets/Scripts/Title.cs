using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField] private SceneObject gameScene;

    public void OnClickStartButton()
    {
        SceneManager.LoadScene(gameScene);
    }
}
