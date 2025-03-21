using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassEnable : MonoBehaviour
{
    public Animator anim;
    public SpriteRenderer SR;

    // Start is called before the first frame update
    void Start()
    {
        anim.enabled = false;
        SR.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Light")
        {
            anim.enabled = true;
            SR.enabled = true;
        }

        else
        {
            anim.enabled = false;
            SR.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        anim.enabled = false;
        SR.enabled = false;
    }
}
