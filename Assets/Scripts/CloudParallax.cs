using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudParallax : MonoBehaviour {

    public float speed;
    private bool movingRight = false;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (movingRight == true)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingRight = false;
        }

       /* else if (movingRight == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingRight = true;
        } */
    }
}
