using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject startPos;
    public GameObject Enemy;

    public static GameManager instance;
    public Text textGold;
    public int Gold;
    public int tempGold;

    private void Start()
    {
        instance = this;
        Gold = 0;
        StartCoroutine("EnemySpawn");
    }
    private void Update()
    {
        if(Gold != tempGold)
        {
            tempGold = Gold;
            textGold.text = Gold.ToString();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Gold += 10;
            textGold.text = Gold.ToString();
        }
    }
    IEnumerator EnemySpawn()
    {
        Instantiate(Enemy, startPos.transform.position + new Vector3(1,2,-1), Quaternion.identity);
        yield return new WaitForSeconds(5.0f);
        StartCoroutine("EnemySpawn");

    }
}