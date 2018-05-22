using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour {

    public GameObject explosionSphere;
    public GameObject bomb;

    public float MaxHP;
    float HP;

    void Start() {
        HP = MaxHP;
    }
    void Update() {

        SuicideBomb();
        DropBomb();

        if (HP <= 0)
        {
            Die();
        }

    }

    public void SuicideBomb()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(explode());
        }
    }

    public void DropBomb()
    {
        if (Input.GetKeyDown(KeyCode.F))
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

    void Die()
    {
        Destroy(gameObject);
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
