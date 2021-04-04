using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public Text playerNameText;
    public Text playerNameText2;

    public GameObject pauseMenuUI;

    public string playerName;

    private void Awake()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/gamesave.typegame", FileMode.Open);
        Save save = (Save)bf.Deserialize(file);
        file.Close();

        playerName = PlayerPrefs.GetString("playerNAME");
        playerNameText.text = playerName;
        playerNameText2.text = playerName;
        pauseMenuUI.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void QuitandReturn()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
