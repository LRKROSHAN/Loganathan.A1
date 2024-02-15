using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Scene currentScene = SceneManager.GetActiveScene();

            if (currentScene.name == "GameStart")
            {
                SceneManager.LoadScene("Game");
            }
            else if (currentScene.name == "GameOver")
            {
                SceneManager.LoadScene("GameStart");
            }
            else if (currentScene.name == "GameWin")
            {
                SceneManager.LoadScene("GameStart");
            }
        }
    }
}
