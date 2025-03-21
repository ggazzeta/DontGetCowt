using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public float speed = 2;
    float life = 1500;
    float currentLife = 1500;
    private float damage = 1.5f;
    private float heal = 1.5f;

    private GameObject Player;
    public GameObject myLight;
    private bool isDamaging = false;

    public Image Background;
    public Image CurrentLightBar;

    public ParticleSystem Leafs;
    private EnergyBar myEnergyBar;
    public Joystick joystick;

    public static bool abducted;

    public bool canAbduct = true;
    private bool usingButton = false;

    void Start()
    {
        myEnergyBar = GameObject.Find("CurrentLightBar").GetComponent<EnergyBar>();
        myLight.GetComponent<SpriteRenderer>().enabled = false;
        myLight.GetComponent<CapsuleCollider2D>().enabled = false;
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        ValidateHealthBar();
        if (!usingButton) {
            ControlLightOnSpaceBar();
        }
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (Player.tag == "Player")
        {
            float posX = (transform.position.x + Input.GetAxis("Horizontal") * Time.deltaTime * speed);

            transform.position = new Vector3(Mathf.Clamp(posX, -8f, 8f), 3.7f, 0);

            float posXTouch = (transform.position.x + joystick.Horizontal * Time.deltaTime * speed);

            transform.position = new Vector3(Mathf.Clamp(posXTouch, -8f, 8f), 3.7f, 0);
        }

    }

    public void ControlLightOnSpaceBar()
    {
        if (Input.GetKey(KeyCode.Space) == true && Player.tag == "Player" && canAbduct)
        {
            ControlLight(true);
        }
        else
        {
            ControlLight(false);
        }
    }

    private void ControlLight(bool enableComponents)
    {
        myLight.GetComponent<SpriteRenderer>().enabled = enableComponents;
        myLight.GetComponent<CapsuleCollider2D>().enabled = enableComponents;
        if (enableComponents) Leafs.Play(); else Leafs.Stop();
        isDamaging = enableComponents;
    }

    private void ValidateHealthBar()
    {
        float ratio = life / currentLife;

        if (ratio == 1)
        {
            canAbduct = true;
            myEnergyBar.SetLightOnOff(outOfLight: false);
        }
        CurrentLightBar.fillAmount = ratio;

        if (isDamaging)
        {
            life -= damage;
            if (life <= 0)
            {
                life = 0;
                canAbduct = false;
                myEnergyBar.SetLightOnOff(outOfLight : true);
                myLight.GetComponent<SpriteRenderer>().enabled = false;
                myLight.GetComponent<CapsuleCollider2D>().enabled = false;
            }
        }

        if (life < currentLife && !isDamaging)
        {
            if (GameManager.PauseMyGame == false)
            {
                life += heal;
                if (life >= currentLife)
                {
                    life = currentLife;
                }
            }

        }
    }

    // Came from the button instead of spacebar
    public void LightButton(bool enableComponents)
    {
        usingButton = enableComponents;
        if (enableComponents && canAbduct)
        {
            ControlLight(enableComponents);
        }
        else
        {
            ControlLight(false);
        }
    }

    public void Abduction()
    {
        Debug.Log("Quitting the game...");
        Application.Quit();
    }
}
