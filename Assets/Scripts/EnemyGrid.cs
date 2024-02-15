using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyGridSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject eBulletPrefab; 
    public Transform playerTransform; 
    public int rows = 3;
    public int columns = 3;
    public float spacing = 12f;
    public float moveSpeed = 2f;
    public float stepDown = 1f;

    public float bulletSpeed = 10f;
    public float shootingIntervalMin = 2f; 
    public float shootingIntervalMax = 5f; 

    private Vector3 direction = Vector3.right;
    private float rightLimit = 15f;
    private float leftLimit = -35f;
    private int totalEnemies = 9; 
    private int enemiesDestroyed = 0; 
    void Start()
    {
        GenerateGrid();
    }

    void Update()
    {
        MoveGrid();
        CheckBoundsAndChangeDirection();
    }
    
    void GenerateGrid()
    {
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                Vector3 position = new Vector3(x * spacing, 0, y * spacing) + transform.position;
                GameObject newEnemy = Instantiate(enemyPrefab, position, Quaternion.identity, transform);
                newEnemy.name = $"Enemy_{x}_{y}";
                StartShooting(newEnemy.transform);
            }
        }
    }

    void StartShooting(Transform enemyTransform)
    {
        StartCoroutine(EnemyShoot(enemyTransform));
    }

    IEnumerator EnemyShoot(Transform enemyTransform)
    {
        float initialDelay = Random.Range(shootingIntervalMin, shootingIntervalMax);
        yield return new WaitForSeconds(initialDelay);

        while (enemyTransform != null)
        {
            GameObject bullet = Instantiate(eBulletPrefab, enemyTransform.position, Quaternion.identity);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.forward * -bulletSpeed; 
            }
            else
            {
                Debug.LogError("Enemy bullet prefab does not have a Rigidbody component.");
            }

            float delayBetweenShots = Random.Range(shootingIntervalMin, shootingIntervalMax);
            yield return new WaitForSeconds(delayBetweenShots);
        }
    }
    public void EnemyDestroyed()
    {
        enemiesDestroyed++;
        if (enemiesDestroyed >= totalEnemies)
        {
            SceneManager.LoadScene("GameWin");
        }
    }

    void MoveGrid()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    void CheckBoundsAndChangeDirection()
    {
        if ((direction == Vector3.right && transform.position.x >= rightLimit) || 
            (direction == Vector3.left && transform.position.x <= leftLimit))
        {
            ChangeDirectionAndStepDown();
        }
    }

    public void ChangeDirectionAndStepDown()
    {
        if (!isChangingDirection)
        {
            direction *= -1;
            transform.Translate(Vector3.forward * stepDown, Space.World);
            isChangingDirection = true;
            Invoke(nameof(ResetDirectionChange), 0.5f);
        }
    }
    
    private bool isChangingDirection = false;

    private void ResetDirectionChange()
    {
        isChangingDirection = false;
    }
}
