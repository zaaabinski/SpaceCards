using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject Enemy1;
    Vector3 randomPos;
    // Start is called before the first frame update
    int x = 0, times = 0;
    public int nrOfEn = 0;
    void Start()
    {
        Invoke("StartSpawning", 0.5f);
    }
    void StartSpawning()
    {
        StartCoroutine(SpawnEnemies());
    }
    IEnumerator SpawnEnemies()
    {
        if(times % 4==0)
        {
            x++;
        }
        if(nrOfEn<=50)
        {

        for(int i=0; i<=x; i++)
        {
        randomPos = new Vector3(Random.Range(-24,24), Random.Range(1,1), Random.Range(-24, 24));
        Instantiate(Enemy1, randomPos, Quaternion.identity);
            nrOfEn++;
        }
        }
        yield return new  WaitForSeconds(15);
        times++;

        StartCoroutine(SpawnEnemies());
    }
}
