using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCollider : MonoBehaviour
{
    //private GameObject word;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("FAILED");
        //Destroy(word);
    }
}
