using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{
    public void ExitGame() 
    {
        Application.Quit();
        //Debug.Log("Quit button function check");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("ClickerMain");
    }
}
