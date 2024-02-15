using UnityEngine;

public class ShieldBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Destroy(other.gameObject); // Also destroy the bullet that hit the shield
        }
        else if (other.CompareTag("EBullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
