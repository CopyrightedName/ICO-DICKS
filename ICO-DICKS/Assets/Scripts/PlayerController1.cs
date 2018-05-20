using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController1 : NetworkBehaviour {

    public GameObject explosionSphere;
    public GameObject cam;
    GameObject camInstance;
    bool canExplode;

    void Start() {
        if (isLocalPlayer)
        {
            camInstance = Instantiate(cam, gameObject.transform.position, Quaternion.identity);
        }

    }
    void Update() {
        camInstance.GetComponent<CameraFollow>().target = this.transform;

        SuicideBomb();

    }

    public void SuicideBomb()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(explode());
        }
    }

    public IEnumerator explode()
    {
        GameObject explosionInstance;
        explosionInstance = Instantiate(explosionSphere, gameObject.transform.position, Quaternion.identity);
        canExplode = false;
        yield return new WaitForSeconds(0.3f);
        Destroy(explosionInstance);
        canExplode = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (canExplode)
        {
            if (other.gameObject.CompareTag("explosion"))
            {
                Die();
            }
        }
    }

    void Die()
    {

    }
       
}
