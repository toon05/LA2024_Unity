using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Tweener tweener = transform.DORotate(new Vector3(45, 45, 45), 1f)
            .SetLoops(-1, LoopType.Incremental) // ループタイプを Incremental に設定
            .SetRelative(true) // 相対的に回転角度を加算
            .SetEase(Ease.Linear);
    }
}