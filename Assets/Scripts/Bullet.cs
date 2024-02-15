
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 30f; 

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); 
            Destroy(gameObject); 
            FindObjectOfType<EnemyGridSpawner>().EnemyDestroyed(); 
        }
       
        else if (other.CompareTag("EBullet")) 
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
