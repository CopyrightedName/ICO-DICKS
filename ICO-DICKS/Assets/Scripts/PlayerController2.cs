using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour {

    public GameObject explosionSphere;

    public float MaxHP;
    float HP;

    void Start() {
        HP = MaxHP;

    }
    void Update() {

        SuicideBomb();

        if (HP <= 0)
        {
            Die();
        }
    }

    public void SuicideBomb()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            StartCoroutine(explode());
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
       
}
