using System.Collections;   
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu_Script : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject ControlMenuUI;
    public bool isPaused = false;

    public bool leaveGame;
    public bool WinGame;

    private void Start()
    {
        leaveGame = false;
        WinGame = false;
        ControlMenuUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////
    public void NextChapter()
    {
        WinGame = true;
        StartCoroutine(WinSceneWithDelay(1.5f));
        
    }
    //////////////////////////////////////////////////////////////////////////////////////////
    public void Play_Again()
    {
        // Reload the current scene
        SceneManager.LoadScene(2);

        // Optionally log the reload for debugging
        Debug.Log("Scene Reloaded");
        leaveGame = false;
    }
    ///////////////////////////////////////////////////////////////////////////////////////////
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    ///////////////////////////////////////////////////////////////////////////////////////////
    public void Controls()
    {
        ControlMenuUI.SetActive(true);
    }

    public void ControlBack()
    {
        ControlMenuUI.SetActive(false);
    }
    ///////////////////////////////////////////////////////////////////////////////////////////
    public void Back_Button()
    {
        leaveGame = true;
        StartCoroutine(ReloadSceneWithDelay(1)); // Start coroutine with delay
    }

    private IEnumerator ReloadSceneWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        SceneManager.LoadScene(1); // Reload the scene
        Debug.Log("Scene Reloaded after delay");
    }

    private IEnumerator WinSceneWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        SceneManager.LoadScene(3); // Reload the scene
        Debug.Log("Scene Reloaded after delay");
    }
}
