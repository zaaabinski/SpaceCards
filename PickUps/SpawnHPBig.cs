using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHPBig : MonoBehaviour
{
    public GameObject HPBig;
    public PlayerHealth playerHealth;
    private Vector3 spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ReSpawn());
    }
    private void OnTriggerEnter(Collider other)
    {
        if((other.CompareTag("IsPlayer")) && playerHealth.currentHealth < 100)
        {
            transform.position = new Vector3(0, -15, 0);
            GetComponent<SphereCollider>().enabled = true;
            StartCoroutine(ReSpawn());
        }
        if((other.CompareTag("WorldObjects")) || other.CompareTag("HealPack"))
        {
            SpawnHp();
        }
    }
    void SpawnHp()
    {
        spawnPoint.x = Random.Range(-25f, 25f);
        spawnPoint.z = Random.Range(-25f, 25f);
        spawnPoint.y = Random.Range(0f, 4f);
        HPBig.transform.position = spawnPoint;
        GetComponent<SphereCollider>().enabled = false;
    }
    IEnumerator ReSpawn()
    {
        yield return new WaitForSeconds(45);
        SpawnHp();
    }
}
