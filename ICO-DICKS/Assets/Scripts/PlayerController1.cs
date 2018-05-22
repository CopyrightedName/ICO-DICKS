using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour {

    public GameObject explosionSphere;
    public GameObject bomb;

    public float MaxHP;
    float HP;

    bool canMove;
    public Rigidbody rg;

    public GameObject player;
    public GameObject model;

    bool hasCounted;
    bool canBomb;


    void Start() {
        HP = MaxHP;
        canMove = true;
        canBomb = true;
    }
    void Update() {

        SuicideBomb();
        DropBomb();

        if (HP <= 0)
        {
            StartCoroutine(Die());
        }

        if (FindObjectOfType<GameController>().isPaused)
        {
            rg.isKinematic = true;
        }
        else if(FindObjectOfType<GameController>().isPaused == false)
        {
            rg.isKinematic = false;
        }

    }

    public void SuicideBomb()
    {
        if (Input.GetKeyDown(KeyCode.E) && canMove && canBomb)
        {
            StartCoroutine(explode());
        }
    }

    public void DropBomb()
    {
        if (Input.GetKeyDown(KeyCode.F) && canMove && canBomb)
        {
            StartCoroutine(Bomb());
        }
    }

    public IEnumerator explode()
    {
        GameObject explosionInstance;
        explosionInstance = Instantiate(explosionSphere, gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Destroy(explosionInstance);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("explosion"))
        {
            HP = 0;
            this.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(0, 5), 0, Random.Range(0, 5)) * 250);
        }
    }

    IEnumerator Die()
    {
        if (hasCounted == false)
        {
            FindObjectOfType<GameController>().wins2++;
            hasCounted = true;
        }
        canBomb = false;
        rg.isKinematic = true;
        canMove = false;
        model.SetActive(false);
        yield return new WaitForSeconds(2);
        transform.position = new Vector3(-0.9099998f, 0.5f, -5.56f);
        HP = MaxHP;
        yield return new WaitForSeconds(1);
        model.SetActive(true);
        canMove = true;
        rg.isKinematic = false;
        hasCounted = false;
        canBomb = true;
    }

    IEnumerator Bomb()
    {
        GameObject SphereInstance;
        GameObject BombInstance;
        BombInstance = Instantiate(bomb, transform.position + new Vector3(0, 1, 0), transform.rotation);
        yield return new WaitForSeconds(1);
        SphereInstance = Instantiate(explosionSphere, BombInstance.transform.position, BombInstance.transform.rotation);
        SphereInstance.transform.SetParent(null);
    }

}
