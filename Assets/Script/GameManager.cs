using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject startPos;
    public GameObject Enemy;

    private void Start()
    {
        StartCoroutine("EnemySpawn");       
    }
    IEnumerator EnemySpawn()
    {
        Instantiate(Enemy, startPos.transform.position + new Vector3(1,2,-1), Quaternion.identity);
        yield return new WaitForSeconds(5.0f);
        StartCoroutine("EnemySpawn");

    }
}