using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PressedPlay()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void PressedKeybinds()
    {
        SceneManager.LoadScene("StartScene");
    }
}
