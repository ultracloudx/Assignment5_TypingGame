using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text scoreText;

    [SerializeField]
    public int playerScore;
    [SerializeField]
    public GameObject PauseMenu;
    [SerializeField]
    public GameObject canvas;
    public GameObject gameOverCanvas;

    [SerializeField]
    private string playerName;

    private void Awake()
    {

        Time.timeScale = 1f;
        playerScore = PlayerPrefs.GetInt("loadedScore");
    }

    private void Update()
    {
        int currLives = PlayerPrefs.GetInt("currLivesPref");
        if (currLives == 0)
        {
            Time.timeScale = 0f;
            gameOverCanvas.SetActive(true);
        }
        scoreText.text = playerScore.ToString();
    }

    public void SaveGame()
    {
        Save save = CreateSaveGameObject();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.typegame");
        bf.Serialize(file, save);
        file.Close();

        playerName = PlayerPrefs.GetString("playerNAME");
        save.name = playerName;

        playerScore = save.score;
        scoreText.text = playerScore.ToString();
        Debug.Log("Game Saved! Score saved is = " + save.score +" " + save.name);
    }

    public void LoadGame()
    {
        //1
        if (File.Exists(Application.persistentDataPath + "/gamesave.typegame"))
        {
            
            //2
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.typegame", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            playerName = save.name;
            //PlayerPrefs.SetString("playerNAME", playerName);
            
            playerScore = save.score;
            PlayerPrefs.SetInt("loadedScore", playerScore);
            Debug.Log("Game Loaded Score loaded is = " + save.score + " " + save.name);
            Restart();

        }
        else
        {
            Debug.Log("No Game Saved!");
        }
    }

    public void NewGame()
    {
        Time.timeScale = 1f;
        int currLives = PlayerPrefs.GetInt("livesSelected");
        PlayerPrefs.SetInt("currLivesPref", currLives);
        PlayerPrefs.SetInt("loadedScore", 0);
        scoreText.text = playerScore.ToString();
        Restart();
        
    }

    public void SaveAsJSON()
    {
        Save save = CreateSaveGameObject();
        string json = JsonUtility.ToJson(save);

        Debug.Log("Saving as JSON: " + json);
    }

    public void TESTBUTTON()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/gamesave.typegame", FileMode.Open);
        Save save = (Save)bf.Deserialize(file);
        file.Close();

        playerName = PlayerPrefs.GetString("playerNAME");
        save.name = playerName;

        Debug.Log("NAME: " + save.name + ", SCORE: " + save.score);
        Debug.Log("Variable NAME: " + playerName/*PlayerPrefs.GetString("playerNAME")*/);
        Debug.Log("PLAYERPREF NAME: " + PlayerPrefs.GetString("playerNAME"));
    }

    private Save CreateSaveGameObject()
    {
        Save save = new Save();

        save.score = playerScore;
        save.name = playerName;

        return save;
    }

    public void DEV_endGame()
    {
        Time.timeScale = 0f;
        gameOverCanvas.SetActive(true);
    }

    public void NextScene()
    {
        Save save = CreateSaveGameObject();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.typegame");
        bf.Serialize(file, save);
        file.Close();

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        PauseMenu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
