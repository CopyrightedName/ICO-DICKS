using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject explosionSphere;

	void Start () {
		
	}
	
	void Update () {
        SuicideBomb();
	}

    public void SuicideBomb()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Explode();
        }
    }

    public void Explode()
    {
        Instantiate(explosionSphere, gameObject.transform.position, Quaternion.identity);
    }
}
