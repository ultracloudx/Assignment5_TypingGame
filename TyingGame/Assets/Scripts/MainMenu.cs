using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class MainMenu : MonoBehaviour
{


    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.typegame"))
        {

            //2
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.typegame", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            //3

            //4


            int playerScore = save.score;
            PlayerPrefs.SetInt("loadedScore", playerScore);
            Debug.Log("Game Loaded Score loaded is = " + save.score);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
        else
        {
            Debug.Log("No Game Saved!");
        }
    }


    public void QuitGame()
    {
        Debug.Log("Quit Successful");
        Application.Quit();
    }

    
}
