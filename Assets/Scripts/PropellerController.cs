using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PropellerController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        RotatePropeller();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RotatePropeller()
    {
        this.transform.DORotate(new Vector3(45, 0, 0), 0.5f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
    }

}
