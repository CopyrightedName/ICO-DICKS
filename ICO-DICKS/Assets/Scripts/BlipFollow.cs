using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlipFollow : MonoBehaviour {

    public int type;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(type == 1)
        {
            transform.position = new Vector3(FindObjectOfType<PlayerController1>().transform.position.x, transform.position.y, FindObjectOfType<PlayerController1>().transform.position.z);
        }

        if (type == 2)
        {
            transform.position = new Vector3(FindObjectOfType<PlayerController2>().transform.position.x, transform.position.y, FindObjectOfType<PlayerController2>().transform.position.z);
        }
    }
}
