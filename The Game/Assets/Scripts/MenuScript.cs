using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
 public void ButtonStart()
    {
        SceneManager.LoadScene("Nivel1");
    }
    public void ButtonQuit()
    {
        Application.Quit();
    }
}
