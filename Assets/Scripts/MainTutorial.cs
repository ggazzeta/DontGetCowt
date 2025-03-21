using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainTutorial : MonoBehaviour
{
    public GameObject[] emptyButton;
    public GameObject[] filledButton;
    public GameObject Joystick;
    public GameObject TouchPanel;
    public Text timer;
    public Image myTimer;
    public GameObject ButtonOwner;
    public Image buttonAnimator;
    public GameObject WASDObject;
    public GameObject SpaceObject;

    public TextMeshProUGUI Touch;
    public TextMeshProUGUI Move;
    public TextMeshProUGUI Hold;
    public TextMeshProUGUI Abduct;
    public TextMeshProUGUI myTip;

    public int countTrigger;

    private bool wasAbducted;
    private float alphaLower = 1;
    private float alphaLower2 = 1;
    private float alphaDamage = 0.02f;
    private float alphaDamage2 = 0.03f;
    private float counter = 0.8f;
    private float TipStarter = 0;
    private float TipLoader = 0.04f;
    private float TipTimer = 1f;
    private float TipDamage = 0.0007f;
    private bool Skipped = false;

    private bool hasTouchedJoystick = false;

    // Start is called before the first frame update
    void Start()
    {
#if !UNITY_WEBGL
        WASDObject.SetActive(false);
#endif
        SpaceObject.SetActive(false);
        timer.enabled = false;
        ButtonOwner.SetActive(false);
        GameObject.FindWithTag("MenuDica").GetComponent<CanvasGroup>().alpha = 0;
        buttonAnimator.GetComponent<Animator>().enabled = false;
        for (int i = 0; i < filledButton.Length; i++)
        {
            filledButton[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasTouchedJoystick)
        {
            hasTouchedJoystick = Joystick.GetComponent<DynamicJoystick>().hasTouched || (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D));
        }

        countCows();

        Touch.text = TouchText;
        Move.text = MoveText;
        Hold.text = HoldText;
        Abduct.text = AbductText;
        myTip.text = TipText;


        if (hasTouchedJoystick)
        {
            filledButton[0].SetActive(true);
            alphaLower2 -= alphaDamage2;
            GameObject.FindWithTag("TutorialGrade").GetComponent<CanvasGroup>().alpha = alphaLower2;
        }

        if (PointerDeleter.FirstCheck && countTrigger >= 2)
        {
            filledButton[1].SetActive(true);
            buttonAnimator.GetComponent<Animator>().enabled = true;
            SpaceObject.SetActive(true);
        }

        if (ColliderLight.haveCollided)
        {
            SpaceObject.SetActive(false);
            buttonAnimator.GetComponent<Animator>().enabled = false;
            buttonAnimator.GetComponent<Image>().enabled = false;
            ButtonOwner.SetActive(true);
            filledButton[2].SetActive(true);
            TipStarter += TipLoader;
            GameManager.SlowMo = true;
            GameObject.FindWithTag("MenuDica").GetComponent<CanvasGroup>().alpha = TipStarter;
            TipTimer -= TipDamage;
            myTimer.fillAmount = TipTimer;
            if (TipTimer <= 0 || Skipped)
            {
                ButtonOwner.SetActive(false);
                TipTimer = 0;
                GameObject.FindWithTag("MenuDica").GetComponent<CanvasGroup>().alpha = 0;
                GameManager.SlowMo = false;
                TipStarter -= TipLoader;
            }
        }

        if (wasAbducted)
        {
            filledButton[3].SetActive(true);
            alphaLower -= alphaDamage;
            counter -= Time.deltaTime;
            GetComponent<CanvasGroup>().alpha = alphaLower;
            timer.enabled = true;
            if (counter <= 0)
            {
                Destroy(gameObject);
            }
        }

    }

    public void SkipTip()
    {
        Skipped = true;
    }

    private void countCows()
    {
        int NumberOfCows;
        GameObject[] CowCount = GameObject.FindGameObjectsWithTag("Cows");
        NumberOfCows = CowCount.Length;
        if (NumberOfCows == 1)
        {
            wasAbducted = true;
        }

    }

    private static string _touchText;
    private static string _moveText;
    private static string _holdText;
    private static string _abductText;
    private static string _tipText;

    public static string TouchText
    {
        get { return _touchText.touchText(); }
        set { _touchText = value; }
    }

    public static string MoveText
    {
        get { return _moveText.moveText(); }
        set { _touchText = value; }
    }

    public static string HoldText
    {
        get { return _holdText.holdText(); }
        set { _touchText = value; }
    }

    public static string AbductText
    {
        get { return _abductText.abductText(); }
        set { _touchText = value; }
    }

    public static string TipText
    {
        get { return _tipText.tipText(); }
        set { _touchText = value; }
    }

}
