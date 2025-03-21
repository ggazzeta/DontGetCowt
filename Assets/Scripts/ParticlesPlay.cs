using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesPlay : MonoBehaviour
{

    public ParticleSystem ps;

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Light")
        {
            ps.Play();
        }

    }
}
