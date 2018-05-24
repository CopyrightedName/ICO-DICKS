using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    bool candrop;

    public int bombCount = 5;

    public Text bombText;


    void Start() {
        HP = MaxHP;
        canMove = true;
        canBomb = true;
        candrop = true;
    }
    void Update() {

        bombText.text = "BOMBS: " + bombCount.ToString();

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

        if(bombCount <= 0)
        {
            candrop = false;
        }

        if (bombCount >= 0)
        {
            candrop = true;
        }

    }

    public void SuicideBomb()
    {
        if (Input.GetKeyDown(KeyCode.E) && canMove && canBomb)
        {
            StartCoroutine(explode());
            canBomb = false;
        }
    }

    public void DropBomb()
    {
        if (Input.GetKeyDown(KeyCode.F) && canMove && candrop)
        {
            StartCoroutine(Bomb());
            bombCount = bombCount - 1;
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

        if (other.gameObject.CompareTag("ammo"))
        {
            bombCount = bombCount + 1;
            Destroy(other.gameObject);
        }
    }

    IEnumerator Die()
    {
        if (hasCounted == false)
        {
            FindObjectOfType<GameController>().wins2++;
            hasCounted = true;
        }
        rg.isKinematic = true;
        canMove = false;
        model.SetActive(false);
        yield return new WaitForSeconds(1);
        transform.position = new Vector3(-0.9099998f, 0.5f, -5.56f);
        HP = MaxHP;
        model.SetActive(true);
        canMove = true;
        rg.isKinematic = false;
        hasCounted = false;
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
