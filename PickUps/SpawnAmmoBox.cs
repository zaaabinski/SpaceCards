using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAmmoBox : MonoBehaviour
{
    public GameObject AmmoBox;
    private Vector3 spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ReSpawn());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("IsPlayer"))
        {
            transform.position = new Vector3(0, -15, 0);
            GetComponent<BoxCollider>().enabled = true;
            StartCoroutine(ReSpawn());
        }
        if ((other.CompareTag("WorldObjects")) || other.CompareTag("HealPack"))
        {
            SpawnHp();
        }
    }
    void SpawnHp()
    {
        spawnPoint.x = Random.Range(-25f, 25f);
        spawnPoint.z = Random.Range(-25f, 25f);
        spawnPoint.y = Random.Range(0f, 4f);
        AmmoBox.transform.position = spawnPoint;
        GetComponent<BoxCollider>().enabled = false;
    }
    IEnumerator ReSpawn()
    {
        yield return new WaitForSeconds(20);
        SpawnHp();
    }
}
