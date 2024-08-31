using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMove(new Vector3(3, 3, 3), 1f)
            .OnComplete(() => transform.DORotate(new Vector3(0, 0, 60), 1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
