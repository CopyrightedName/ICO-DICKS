using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombSpawn : MonoBehaviour {

    public List<Transform> pos;
    public GameObject bomb;

    bool canSpawn = true;
    public float spawnTimer;
    float maxSpawnTimer = 100;


    void Start () {
        spawnTimer = maxSpawnTimer;
	}
	
	void Update () {

        if(spawnTimer <= 0)
        {
            spawnTimer = maxSpawnTimer;
            canSpawn = true;
        }

        spawnTimer = spawnTimer - 0.1f;

        StartCoroutine(spawn());
	}

    IEnumerator spawn()
    {
        if (canSpawn)
        {
            Instantiate(bomb, pos[Random.Range(0, pos.Count)].position, Quaternion.identity);
            canSpawn = false;
        }
        return null;
    }
}
