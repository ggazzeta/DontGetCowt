using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class whichLevel : MonoBehaviour
{
    public int[] chooseLevel;
    public int level;

    public TextMeshProUGUI myText;

    public TextMeshProUGUI continueTxt;
    public TextMeshProUGUI newGameTxt;
    public TextMeshProUGUI freeAbductTxt;
    public TextMeshProUGUI menuTxt;
    public TextMeshProUGUI levelSelector;
    public TextMeshProUGUI quitText;

    public GameObject myButton;

    public GameObject[] Botoes;

    public Color myColor;

    public int levelImCurrentlyAt = 0;
    public static bool canPlay = false;

    public GameObject MsgPopUp;

    // Start is called before the first frame update
    void Start()
    {

        if (continueTxt != null)
        {
            continueTxt.text = Continue;
            newGameTxt.text = NewGame;
            freeAbductTxt.text = FreeAbducting;
            menuTxt.text = MainMenu;
            levelSelector.text = LevelSelector;
            quitText.text = Quit;
        }


        if(SceneManager.GetActiveScene().name == "Menu")
        {

            for (int i = 0; i < Botoes.Length; i++)
            {
                Botoes[i].GetComponent<Image>().color = Color.gray;
            }
        }

        foreach (var index in chooseLevel)
        {
            chooseLevel[index] = 0;
        }

        if(MsgPopUp != null)
        {
            MsgPopUp.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

        switch(level)
        {
            case 1:
                chooseLevel[0] = 1;
                break;

            case 2:
                chooseLevel[1] = 1;
                break;

            case 3:
                chooseLevel[2] = 1;
                break;

            case 4:
                chooseLevel[3] = 1;
                break;

            case 5:
                chooseLevel[4] = 1;
                break;

            case 6:
                chooseLevel[5] = 1;
                break;
        }

        if (chooseLevel[0] == 1)
            PlayerPrefs.SetInt("Lvl1", chooseLevel[0]);
        else if (chooseLevel[1] == 1)
            PlayerPrefs.SetInt("Lvl2", chooseLevel[1]);
        else if (chooseLevel[2] == 1)
            PlayerPrefs.SetInt("Lvl3", chooseLevel[2]);
        else if (chooseLevel[3] == 1)
            PlayerPrefs.SetInt("Lvl4", chooseLevel[3]);
        else if (chooseLevel[4] == 1)
            PlayerPrefs.SetInt("Lvl5", chooseLevel[4]);
        else if (chooseLevel[5] == 1)
            PlayerPrefs.SetInt("Lvl6", chooseLevel[5]);


        if(PlayerPrefs.GetInt("Lvl1") >= 1)
        {
            if(myButton != null)
            {
                myButton.GetComponent<UnityEngine.UI.Button>().interactable = true;
                myColor = Color.white;
                myButton.GetComponent<Image>().color = myColor;
            }
            if(SceneManager.GetActiveScene().name == "Menu")
            {
                Botoes[0].GetComponent<Image>().color = Color.white;
            }

            canPlay = true;
        }
        else
        {
            if (myButton != null)
            {
                myButton.GetComponent<UnityEngine.UI.Button>().interactable = false;
                myColor = Color.gray;
                myButton.GetComponent<Image>().color = myColor;
            }
        }

        if (PlayerPrefs.GetInt("Lvl1") == 1 && SceneManager.GetActiveScene().name == "Menu")
        {
            Botoes[1].GetComponent<Image>().color = Color.white;
        }
        if (PlayerPrefs.GetInt("Lvl2") == 1 && SceneManager.GetActiveScene().name == "Menu")
        {
            Botoes[2].GetComponent<Image>().color = Color.white;
        }
        if (PlayerPrefs.GetInt("Lvl3") == 1 && SceneManager.GetActiveScene().name == "Menu")
        {
            Botoes[3].GetComponent<Image>().color = Color.white;
        }
        if (PlayerPrefs.GetInt("Lvl4") == 1 && SceneManager.GetActiveScene().name == "Menu")
        {
            Botoes[4].GetComponent<Image>().color = Color.white;
        }
        if (PlayerPrefs.GetInt("Lvl5") == 1 && SceneManager.GetActiveScene().name == "Menu")
        {
            Botoes[5].GetComponent<Image>().color = Color.white;
        }
        if (PlayerPrefs.GetInt("Lvl6") == 1 && SceneManager.GetActiveScene().name == "Menu")
        {
            Botoes[6].GetComponent<Image>().color = Color.white;
        }


    }

    public void callLevel()
    {
        if (PlayerPrefs.GetInt("Lvl1") == 1 && PlayerPrefs.GetInt("Lvl2") == 0 && SceneManager.GetActiveScene().name == "Menu")
        {
            SceneManager.LoadScene("Mapa1");
        }
        if (PlayerPrefs.GetInt("Lvl2") == 1 && PlayerPrefs.GetInt("Lvl3") == 0 && SceneManager.GetActiveScene().name == "Menu")
        {
            SceneManager.LoadScene("Mapa2");
        }
        if (PlayerPrefs.GetInt("Lvl3") == 1 && PlayerPrefs.GetInt("Lvl4") == 0 && SceneManager.GetActiveScene().name == "Menu")
        {
            SceneManager.LoadScene("Mapa3");
        }
        if (PlayerPrefs.GetInt("Lvl4") == 1 && PlayerPrefs.GetInt("Lvl5") == 0 && SceneManager.GetActiveScene().name == "Menu")
        {
            SceneManager.LoadScene("Mapa4");
        }
        if (PlayerPrefs.GetInt("Lvl5") == 1 && PlayerPrefs.GetInt("Lvl6") == 0 && SceneManager.GetActiveScene().name == "Menu")
        {
            SceneManager.LoadScene("Mapa5");
        }
        if (PlayerPrefs.GetInt("Lvl6") == 1 && SceneManager.GetActiveScene().name == "Menu")
        {
            SceneManager.LoadScene("Mapa6");
        }
    }


    public void callFreeRoam()
    {
        SceneManager.LoadScene("FreeRoam");
    }

    public void loadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void loadLevelOne()
    {
        if(PlayerPrefs.GetInt("Lvl1") == 1)
        {
            SceneManager.LoadScene("Mapa1");
        }
        else
        {
            noAccessMsg(NoAccess);
        }
    }

    public void loadLevelTwo()
    {
        if (PlayerPrefs.GetInt("Lvl2") == 1)
        {
            SceneManager.LoadScene("Mapa2");
        }
        else
        {
            noAccessMsg(NoAccess);
        }
    }

    public void loadLevelThree()
    {
        if (PlayerPrefs.GetInt("Lvl3") == 1)
        {
            SceneManager.LoadScene("Mapa3");
        }
        else
        {
            noAccessMsg(NoAccess);
        }
    }

    public void loadLevelFour()
    {
        if (PlayerPrefs.GetInt("Lvl4") == 1)
        {
            SceneManager.LoadScene("Mapa4");
        }
        else
        {
            noAccessMsg(NoAccess);
        }
    }

    public void loadLevelFive()
    {
        if (PlayerPrefs.GetInt("Lvl5") == 1)
        {
            SceneManager.LoadScene("Mapa5");
        }
        else
        {
            noAccessMsg(NoAccess);
        }
    }

    public void loadLevelSix()
    {
        if (PlayerPrefs.GetInt("Lvl6") == 1)
        {
            SceneManager.LoadScene("Mapa6");
        }
        else
        {
            noAccessMsg(NoAccess);
        }
    }

    private static string _continue;
    private static string _newGame;
    private static string _freeAbducting;
    private static string _mainMenu;
    private static string _levelSelector;
    private static string _quit;

    public static string Continue
    {
        get { return _continue.ContinueButton(); }
        set { _continue = value; }
    }
    public static string NewGame
    {
        get { return _newGame.NewGameButton(); }
        set { _newGame = value; }
    }
    public static string FreeAbducting
    {
        get { return _freeAbducting.FreeAbductingButton(); }
        set { _freeAbducting = value; }
    }
    public static string MainMenu
    {
        get { return _mainMenu.MainMenuButton(); }
        set { _mainMenu = value; }
    }

    public static string LevelSelector
    {
        get { return _levelSelector.LevelSelectorText(); }
        set { _levelSelector = value; }
    }

    public static string Quit
    {
        get { return _quit.QuitText(); }
        set { _quit = value; }
    }

    private static string _noAccess;

    public static string NoAccess
    {
        get { return _noAccess.noAccessToTheLvl(); }
        set { _noAccess = value; }
    }

    public void noAccessMsg(string outText)
    {
        if(MsgPopUp != null)
        {
            myText.text = outText;
            MsgPopUp.SetActive(true);
        }
    }

    public void exitMsg()
    {
        if (MsgPopUp != null)
        {
            MsgPopUp.SetActive(false);
        }
    }

}
