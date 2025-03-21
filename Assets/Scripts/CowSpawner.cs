using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowSpawner : MonoBehaviour
{
    public GameObject Cows;
    Vector2 whereToSpawn;
    float spawnRate;
    float nextSpawn = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        spawnRate = Random.Range(3f, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            spawnRate = Random.Range(2f, 8f);
            nextSpawn = Time.time + spawnRate;
            whereToSpawn = new Vector2(transform.position.x, transform.position.y);
            Instantiate(Cows, whereToSpawn, Quaternion.identity);
        }

    }
}
