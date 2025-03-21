using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CowCounter : MonoBehaviour
{
    public static float cowCounter;
    public Text cowScore;
    public Text cowTotal;
    public static int NumberOfCows;

    public bool isFreeRoam;

    private void Start()
    {
        cowCounter = 0;
        GameObject[] CowCount = GameObject.FindGameObjectsWithTag("Cows");
        NumberOfCows = CowCount.Length;
        cowTotal.text = "/ " + NumberOfCows;
    }

    // Update is called once per frame
    void Update()
    {
        string cowCaught = cowCounter.ToString();
        cowScore.text = ": " + cowCaught;

        if(cowCounter == NumberOfCows)
        {
            if(!isFreeRoam)
                FindObjectOfType<GameManager>().WinGame();

        }
    }
}
