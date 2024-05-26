using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// MainMenu. Skickar spelaren till huvudscenen.
/// </summary>
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
