using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroll : MonoBehaviour
{

    public GameObject[] Holders;
    public UnityEngine.UI.Button[] buttons;

    // Start is called before the first frame update
    void Start()
    {

        Holders[1].SetActive(false);
        Holders[0].SetActive(true);
        buttons[0].enabled = true;
        buttons[1].enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void LoadNextPage()
    {
        Holders[0].SetActive(false);
        Holders[1].SetActive(true);
        buttons[0].enabled = false;
        buttons[1].enabled = true;
    }

    public void LoadLastPage()
    {
        Holders[1].SetActive(false);
        Holders[0].SetActive(true);
        buttons[0].enabled = true;
        buttons[1].enabled = false;
    }

}
