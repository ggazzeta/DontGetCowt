using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour {

    public GameObject clouds;
    float randY;
    Vector2 whereToSpawn;
    public float spawnRate = 100f;
    float nextSpawn = 0.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randY = Random.Range(0 , -0.2f);
            whereToSpawn = new Vector2(-17, randY);
            Instantiate(clouds, whereToSpawn, Quaternion.identity);
        }

	}
}
