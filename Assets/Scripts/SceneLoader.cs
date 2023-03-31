using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string TitleSceneString = "TitleScreen";
    [SerializeField] private string StartingSceneString = "Castle Level";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (this.gameObject.tag)
            {
                case "WarpNext":
                    PlayNextScene();
                    break;
                case "WarpPrevious":
                    PlayPreviousScene();
                    break;
                default:
                    break;
            }
        }
    }

    public void PlayGame()
    {
        GoToSpecifiedScene(StartingSceneString);
        PlayerPrefs.SetInt("savedSc4", 0); //resets value of PlayerPrefs "savedSc4"
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Player has exit the game");
    }

    public void GoToTitle()
    {
        GoToSpecifiedScene(TitleSceneString);
    }

    public void PlayNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayPreviousScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void GoToSpecifiedScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
