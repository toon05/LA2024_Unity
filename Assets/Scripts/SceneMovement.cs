using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMovement : MonoBehaviour
{
    [SerializeField] private SceneObject titleScene;
    [SerializeField] private SceneObject gameScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        public void OnClickRestartButton()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void OnClickTitleButton()
    {
        SceneManager.LoadScene(titleScene);
    }
}
