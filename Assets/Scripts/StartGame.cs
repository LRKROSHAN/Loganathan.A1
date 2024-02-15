// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class StartGame : MonoBehaviour
// {
//     void Update()
//     {
//         // Check if the Enter key is pressed
//         if (Input.GetKeyDown(KeyCode.Return))
//         {
//             // Load the Game scene
//             SceneManager.LoadScene("Game");
//         }
//     }
// }

using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    void Update()
    {
        // Check if the Return key is pressed
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Determine the current scene
            Scene currentScene = SceneManager.GetActiveScene();

            // If the current scene is GameStart, load the Game scene
            if (currentScene.name == "GameStart")
            {
                SceneManager.LoadScene("Game");
            }
            // If the current scene is GameOver, load the GameStart scene
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
