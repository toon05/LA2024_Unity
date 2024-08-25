using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private AudioSource seSource;
    [SerializeField] private AudioClip seClip;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shot();
        }
    }

    void Shot()
    {
        seSource.PlayOneShot(seClip);
        int distance = 50;
        Vector3 center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = playerCamera.ScreenPointToRay(center);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance))
        {
            if (hitInfo.collider.gameObject.tag == "Enemy")
            {
                Renderer renderer = hitInfo.collider.GetComponent<Renderer>();
                ChangeColor(renderer).Forget();
                hitInfo.collider.SendMessage("Damage");
            }
        }
    }

    async UniTask ChangeColor(Renderer renderer)
    {
        renderer.material.color = Color.red;
        await UniTask.Delay(200);
        renderer.material.color = Color.white;
    }
}