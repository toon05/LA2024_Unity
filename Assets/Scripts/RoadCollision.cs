using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("hit");
        foreach (ContactPoint point in col.contacts)
        {
            Vector3 relativePoint = transform.InverseTransformPoint(point.point);

            // ご提示いただいたコードだと左右が逆のように思い、勝手に入れ替えてしまいましたが
            // 元々の左右で正しいようでしたら元に戻してしまってください
            if (relativePoint.x > 0.2)
                Debug.Log("Right");

            else if (relativePoint.x < -0.2)
                Debug.Log("Left");

            if (relativePoint.y > 0.5)
                Debug.Log("Up");

            if (relativePoint.z > 0.2)
                Debug.Log("Forward");

            else if (relativePoint.z < -0.2)
                Debug.Log("Back");

        }
    }

}
