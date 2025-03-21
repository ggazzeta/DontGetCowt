using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerDeleter : MonoBehaviour
{

    public Image Pointer;
    private float counter = 1f;
    private bool canCount;
    public static bool FirstCheck;

    // Start is called before the first frame update
    void Start()
    {
        canCount = false;
        FirstCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canCount)
        {
            counter -= Time.deltaTime;
            Pointer.color = new Color(0f, 1f, 0f, counter);
            if (counter <= 0)
            {
                counter = 0;
                FirstCheck = true;
                Destroy(gameObject);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.Find("TutorialCanvas").GetComponent<MainTutorial>().countTrigger++;
            canCount = true;
        }
    }
}
