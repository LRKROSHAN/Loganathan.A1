using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(gameObject); // Destroy this enemy
            Destroy(other.gameObject); // Optionally, destroy the bullet as well
        }
    }
}
