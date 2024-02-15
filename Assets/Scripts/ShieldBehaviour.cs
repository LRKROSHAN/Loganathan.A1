using UnityEngine;

public class ShieldBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Destroy(other.gameObject); 
        }
        else if (other.CompareTag("EBullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
