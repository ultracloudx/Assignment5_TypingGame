using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class NewGameScript : MonoBehaviour
{
    public string userNameInput;
    public GameObject warningText;
    public GameObject inputField;
    public Button PlayButton;
    public Dropdown dropdown;

    private void Awake()
    {
        setDifficultyDropdown(dropdown.value);
        Debug.Log("dropdown value is " + dropdown.value);
    }

    public void StoreName()
    {
        userNameInput = inputField.GetComponent<Text>().text;
        Debug.Log(userNameInput);
    }

    public void playButton()
    {
        if (userNameInput == "")
        {
            Debug.Log("No Name!");
            warningText.SetActive(true);
        }
        else
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.typegame", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            string playerName = save.name;

            PlayerPrefs.SetInt("loadedScore", 0);
            PlayerPrefs.SetString("playerNAME", userNameInput);
            warningText.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void setDifficultyDropdown(int difficultyIndex)
    {
        int i = 0;

        switch (difficultyIndex)
        {
            case 0:
                i = 0;
                PlayerPrefs.SetInt("difficultySelected", i);
                PlayerPrefs.SetInt("livesSelected", 2);
                PlayerPrefs.SetInt("currLivesPref", 2);
                Debug.Log("SLOW " + i);
                break;
            case 1:
                i = 1;
                PlayerPrefs.SetInt("difficultySelected", i);
                PlayerPrefs.SetInt("livesSelected", 3);
                PlayerPrefs.SetInt("currLivesPref", 3);
                Debug.Log("MEDIUM " + i);
                break;
            case 2:
                i = 2;
                PlayerPrefs.SetInt("difficultySelected", i);
                PlayerPrefs.SetInt("livesSelected", 5);
                PlayerPrefs.SetInt("currLivesPref", 5);
                Debug.Log("FAST " + i);
                break;
            default:
                i = 0;
                PlayerPrefs.SetInt("difficultySelected", i);
                PlayerPrefs.SetInt("livesSelected", 2);
                PlayerPrefs.SetInt("currLivesPref", 5);
                Debug.Log("SLOW " + i);
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
