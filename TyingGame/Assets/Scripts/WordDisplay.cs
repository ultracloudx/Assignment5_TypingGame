using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WordDisplay : MonoBehaviour
{
    public Text text;
    private float fallSpeed;
    
    //public Rigidbody2D rb;

    private int currLives;

    private void Awake()
    {
        

        int prefCheck = PlayerPrefs.GetInt("difficultySelected");
        switch (prefCheck)
        {
            case (0):
                fallSpeed = 0.5f;
                break;
            case (1):
                fallSpeed = 1.0f;
                break;
            case (2):
                fallSpeed = 2.0f;
                break;
            case (3):
                //load from save
            default:
                fallSpeed = 1.0f;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EndColliderTag")
        {
            int currLives = PlayerPrefs.GetInt("currLivesPref");
            currLives--;

            PlayerPrefs.SetInt("currLivesPref", currLives);
            Debug.Log("LIVES: " + currLives);
            Debug.Log("LOST LIFE");
            Destroy(this.gameObject);
        }
            
    }
    public void SetWord(string word)
    {
        text.text = word;
    }

    public void RemoveLetter()
    {
        text.text = text.text.Remove(0, 1);
        text.color = Color.red;
    }

    public void RemoveWord()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Translate(0f, -fallSpeed * Time.deltaTime, 0f);
    }

    public void increaseScore(int score)
    {
        score++;
    }
}
