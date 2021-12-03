using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    public GameObject Enemy;
    public int xPos;
    public int zPos;
     int enemyCount;


    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while(enemyCount < 10)
        {
            xPos = Random.Range(-21, 45);
            zPos = Random.Range(-35, 35);
            Instantiate(Enemy, new Vector3(xPos, 0, zPos), Quaternion.identity);
            yield return new WaitForSeconds(2f);
            enemyCount += 1;

        }
    }

    
}
