using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawnerScript : MonoBehaviour
{
    public GameObject cloud;
    public float spawnRate = 2;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        SpawnCloud();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnCloud();
        }
    }

    private void SpawnCloud()
    {
        timer = 0;
        spawnRate = Random.Range(Time.deltaTime, Time.deltaTime * 600);


        Instantiate(cloud, new Vector3((transform.position.x), Random.Range(2f, 3f), 2), transform.rotation);
    }
}
