using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject LevelSelection;
    public GameObject PlayOptions;
    public Animator myAnimator;
    public GameObject QuitButton;

    void Start()
    {
        var animator = GetComponent<Animator>();
        PlayOptions.SetActive(false);
        LevelSelection.SetActive(false);

#if UNITY_WEBGL
        UnityEngine.UI.Button buttonElementQuitBtn = QuitButton.GetComponent<UnityEngine.UI.Button>();
        buttonElementQuitBtn.interactable = false;
#endif
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void OpenPlayOptions()
    {
        myAnimator.SetBool("canLeave", false);
        PlayOptions.SetActive(true);
    }

    public void ClosePlayOptions()
    {
        myAnimator.SetBool("canLeave", true);
        PlayOptions.SetActive(false);
    }


    private static string _myTxtMsg;

    public static string LvlSelectionTxt
    {
        get { return _myTxtMsg.textNoAccessOutside(); }
        set { _myTxtMsg = value; }
    }


    public void OpenLevelSelection()
    {
        if(whichLevel.canPlay)
        {
            LevelSelection.SetActive(true);
        }
        else
        {
            whichLevel lvl = GameObject.FindWithTag("LevelSelector").GetComponent<whichLevel>();
            lvl.noAccessMsg(LvlSelectionTxt);
            Debug.Log("Nope");
        }

    }

    public void CloseLevelSelection()
    {
        LevelSelection.SetActive(false);
    }
}
