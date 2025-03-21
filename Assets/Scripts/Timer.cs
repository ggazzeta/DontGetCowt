using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text timerText;
    private float startTime;
    public float Min, Sec = 0;
    float Minuto;
    float Segundo;


    private void Awake()
    {
        Minuto = 0;
        Segundo = 0;
    }

    // Use this for initialization
    void Start()
    {
        startTime = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {

        float t = Time.time - startTime;

        Minuto = ((int)t / 60);
        Segundo = (t % 60);

        string minutes = Minuto.ToString();
        string seconds = Segundo.ToString("0");

        Min = float.Parse(minutes);
        Sec = float.Parse(seconds);

        if (Minuto <= 9 && Segundo <= 9)
        {
            timerText.text = "0" + minutes + ":" + "0" + seconds;
        }

        else if (Minuto <= 9)
        {
            timerText.text = "0" + minutes + ":" + seconds;
        }

        else if (Segundo <= 9)
        {
            timerText.text = minutes + ":" + "0" + seconds;
        }

        else
        {
            timerText.text = minutes + ":" + seconds;
        }
    }

}
