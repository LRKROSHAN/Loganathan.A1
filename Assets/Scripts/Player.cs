using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public Camera firstPersonCamera;
    public Camera thirdPersonCamera;
    public float bulletSpeed = 30f; // 

    private bool isThirdPerson = true; 

    void Start()
    {
        UpdateCameraView();
    }

    void Update()
    {
        HandleMovement();
        HandleShooting();
        ToggleCameraView();
    }

    void HandleMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(moveHorizontal, 0f, 0f);
    }

    void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        if (bulletPrefab && shootPoint)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = shootPoint.forward * bulletSpeed;
            }
            else
            {
                Debug.LogError("Bullet prefab does not have a Rigidbody component.");
            }
        }
    }

    void ToggleCameraView()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            isThirdPerson = !isThirdPerson;
            UpdateCameraView();
        }
    }

    void UpdateCameraView()
    {
        firstPersonCamera.gameObject.SetActive(!isThirdPerson);
        thirdPersonCamera.gameObject.SetActive(isThirdPerson);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EBullet"))
        {
            EndGame();
        }
    }
    void EndGame()
    {
        Debug.Log("Game Over! Player hit by an enemy bullet.");

        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
}

}
