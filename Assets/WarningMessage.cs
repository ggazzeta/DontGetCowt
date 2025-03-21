using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WarningMessage : MonoBehaviour
{
    public int whichLevel;
    public GameManager GameManager;

    public float panelOn = 0;

    bool wasShown = false;

    public TextMeshProUGUI title;
    public TextMeshProUGUI body;
    bool finishTutorial = false;
    public UnityEngine.UI.Button okButton;

    float buttonCharge = 0;
    float buttonLoadSpeed = .5f;

    // Start is called before the first frame update
    void Start()
    {
        chooseLevel();
        okButton.interactable = false;
        GameManager = GetComponent<GameManager>();
    }

    void chooseLevel()
    {
        switch (whichLevel)
        {
            case 2:
                GameManager.SlowMo = true;
                title.text = FaseTwoHead;
                body.text = FaseTwoText;
                break;

            case 3:
                GameManager.SlowMo = true;
                title.text = FaseThreeHead;
                body.text = FaseThreeText;
                break;

            case 4:
                GameManager.SlowMo = true;
                title.text = FaseFourHead;
                body.text = FaseFourText;
                break;

            case 5:
                break;

            case 6:
                break;
        }
    }

    public void fadeOut()
    {
        finishTutorial = true;
    }

    // Update is called once per frame
    void Update()
    {

        if(!wasShown)
        {
            panelOn += 10 * Time.deltaTime;
        }

        if(panelOn >= 1)
        {
            panelOn = 1;
            wasShown = true;
            GameManager.SlowMo = false;
            GameManager.PauseMyGame = true;
        }

        gameObject.GetComponent<CanvasGroup>().alpha = panelOn;

        buttonCharge += buttonLoadSpeed * Time.unscaledDeltaTime;

        okButton.image.fillAmount = buttonCharge;

        if(buttonCharge >= 1)
        {
            buttonCharge = 1;
            okButton.interactable = true;
        }

        if (finishTutorial)
        {
            GameManager.PauseMyGame = false;
            panelOn -= Time.deltaTime;
            if (panelOn <= 0)
            {
                panelOn = 0f;
                finishTutorial = false;
                gameObject.SetActive(false);
            }
        }
    }

    private static string _faseTwoText;
    private static string _faseTwoHeadText;
    private static string _faseThreeText;
    private static string _faseThreeHeadText;
    private static string _faseFourText;
    private static string _faseFourHeadText;

    public static string FaseTwoHead
    {
        get { return _faseTwoHeadText.FaseTwoHead(); }
        set { _faseTwoHeadText = value; }
    }
    public static string FaseThreeHead
    {
        get { return _faseThreeHeadText.FaseThreeHead(); }
        set { _faseThreeHeadText = value; }
    }
    public static string FaseFourHead
    {
        get { return _faseFourHeadText.FaseFourHead(); }
        set { _faseFourHeadText = value; }
    }

    public static string FaseTwoText
    {
        get { return _faseTwoText.FaseTwo(); }
        set { _faseTwoText = value; }
    }

    public static string FaseThreeText
    {
        get { return _faseThreeText.FaseThree(); }
        set { _faseThreeText = value; }
    }
    public static string FaseFourText
    {
        get { return _faseFourText.FaseFour(); }
        set { _faseFourText = value; }
    }

}
