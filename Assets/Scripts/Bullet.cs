// using UnityEngine;

// public class Bullet : MonoBehaviour
// {
//     public float speed = 30f; // Speed of the bullet

//     void Update()
//     {
//         // Move the bullet forward
//         transform.Translate(Vector3.forward * speed * Time.deltaTime);
//     }

//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Enemy")) // Make sure your enemy GameObjects have the tag "Enemy"
//         {
//             Destroy(other.gameObject); // Destroy the enemy
//             Destroy(gameObject); // Destroy the bullet
//         }
//     }
// }
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 30f; // Speed of the bullet

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); // Destroy the enemy
            Destroy(gameObject); // Destroy this bullet
            FindObjectOfType<EnemyGridSpawner>().EnemyDestroyed(); // Notify the spawner that an enemy has been destroyed
        }
        // else if (other.CompareTag("Shield")) // React to shield 
        // {
        //     Destroy(gameObject); // Destroy this bullet if it hits a shield or an enemy bullet
        // }
        else if (other.CompareTag("EBullet")) // React to enemy bullets
        {
            Destroy(gameObject); // Destroy this bullet if it hits a shield or an enemy bullet
            Destroy(other.gameObject);
        }
    }
}
