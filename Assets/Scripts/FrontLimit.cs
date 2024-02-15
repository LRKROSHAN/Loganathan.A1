using UnityEngine;
using UnityEngine.SceneManagement;

public class FrontLimit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Load the Game Over scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }
    }
}
