using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInput : MonoBehaviour
{
    public WordManager wordManager;

    // Start is called before the first frame update
    private void Update()
    {

        foreach (char letter in Input.inputString)
        {
            Debug.Log(letter);
            wordManager.TypeLetter(letter);
        }
    }
}
