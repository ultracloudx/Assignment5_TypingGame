using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsMenu : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Quit Successful");
        Application.Quit();
    }

    public void ReturnToMainMenu()
    {
        Debug.Log("Return to Main Menu");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
