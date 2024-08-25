using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;

public class NewBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        GenerateCube().Forget();
        Tweener tweener = transform.DORotate(new Vector3(0, 0, 45), 1f)
            .SetLoops(-1, LoopType.Incremental) // ループタイプを Incremental に設定
            .SetRelative(true) // 相対的に回転角度を加算
            .SetEase(Ease.Linear);
    }

    async UniTask GenerateCube()
    {
        for (int i = 0; i < 4; i++)
        {
            Instantiate(cube, new Vector3(0, 2, 0), Quaternion.identity, this.transform);
            // 一秒待機
            await UniTask.Delay(2000);
        }
    }
}