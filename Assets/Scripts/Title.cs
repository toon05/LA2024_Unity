using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField] private SceneObject [] stages;

    public void OnClickStartButton( int index )
    {
        SceneManager.LoadScene(stages[index]);
    }
}