using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLanguage : MonoBehaviour
{
    public void isEnglish()
    {
        PlayerPrefs.SetInt("Language", 1);
        SceneManager.LoadScene("Menu");
    }

    public void isPortugues()
    {
        PlayerPrefs.SetInt("Language", 2);
        SceneManager.LoadScene("Menu");
    }

}
