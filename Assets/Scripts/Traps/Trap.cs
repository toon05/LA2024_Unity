using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerLifeCycleManager>().Respawn();
        }
    }
}
