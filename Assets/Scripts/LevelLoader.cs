using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int delayInSeconds = 2;
    int currentSceneIndex;

    public void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 0)
        {
            LoadNextScene();
        }
    }

    public void LoadNextScene()
    {
        StartCoroutine(WaitAndLoadNextScene());
    }

    private IEnumerator WaitAndLoadNextScene()
    {
        yield return new WaitForSeconds(delayInSeconds);

        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadLoseScene()
    {
        SceneManager.LoadScene("Lose Screen");
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadOptionsScene()
    {
        SceneManager.LoadScene("Options Screen");
    }
}
