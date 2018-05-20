using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rg;
    public float MoveSpeed;
    public float rotSpeed;
    public GameObject model;

	void Start () {
		
	}
	
	void Update () {
        Movement();
	}

    void Movement()
    {
        /*
        float MoveDirX;
        float MoveDirZ;

        MoveDirX = Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime;
        MoveDirZ = Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime;
        transform.Translate(new Vector3(MoveDirX, 0, MoveDirZ));

        if(MoveDirX <= -1)
        {
            model.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (MoveDirX <= 1)
        {
            model.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (MoveDirZ <= -1)
        {
            model.transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        if (MoveDirZ <= 1)
        {
            model.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        */

        if (Input.GetKey(KeyCode.W))
        {
            rg.velocity = new Vector3(rg.velocity.x, rg.velocity.y, MoveSpeed);
            model.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -90, 0), rotSpeed);

        }

        if (Input.GetKey(KeyCode.S))
        {
            rg.velocity = new Vector3(rg.velocity.x, rg.velocity.y, -MoveSpeed);
            model.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), rotSpeed);

        }

        if (Input.GetKey(KeyCode.A))
        {
            rg.velocity = new Vector3(-MoveSpeed, rg.velocity.y, rg.velocity.z);
            model.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -180, 0), rotSpeed);

        }

        if (Input.GetKey(KeyCode.D))
        {
            rg.velocity = new Vector3(MoveSpeed, rg.velocity.y, rg.velocity.z);
            model.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), rotSpeed);

        }


        if (Input.GetKeyUp(KeyCode.W))
        {
            rg.velocity = new Vector3(rg.velocity.x, rg.velocity.y, 0);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            rg.velocity = new Vector3(rg.velocity.x, rg.velocity.y, 0);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            rg.velocity = new Vector3(0, rg.velocity.y, rg.velocity.z);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            rg.velocity = new Vector3(0, rg.velocity.y, rg.velocity.z);
        }

    }
}
