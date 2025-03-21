using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderLight : MonoBehaviour
{
    public static bool haveCollided;
    public float counter = 2f;

    // Start is called before the first frame update
    void Start()
    {
        haveCollided = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(haveCollided)
        {
            counter -= Time.deltaTime;
            if (counter <= 0)
            {
                counter = 0;
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Light")
        {
            haveCollided = true;
        }
    }

}
