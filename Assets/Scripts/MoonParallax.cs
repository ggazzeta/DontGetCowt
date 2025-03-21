using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonParallax : MonoBehaviour
{
    public float speed;
    private bool movingRight = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (movingRight == true)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingRight = false;
        }

    }
}