using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class MusicToggle : MonoBehaviour
{
    public Toggle musicToggle;

    // Start is called before the first frame update
    public void ToggleMusic()
    {
        if (musicToggle.isOn)
        {
            Debug.Log("Music On");
            FindObjectOfType<AudioManager>().Play("BGM");
        }
        else
        {
            Debug.Log("Music OFF");
            FindObjectOfType<AudioManager>().Pause("BGM");
        }
    }
}
