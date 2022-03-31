using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject[] WayPoint;
    public Vector3 Pos;
    public int CurrentHp;
    int count;
    // Start is called before the first frame update
    void Awake()
    {
        WayPoint = new GameObject[4];
        for(int i=0; i<4; i++)
        {
            WayPoint[i] = GameObject.Find("WayPoint" + (i + 1));
        }
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Pos = transform.position;
        transform.Translate(Vector3.forward * 2 * Time.deltaTime);
        transform.LookAt(WayPoint[count].transform);
        if(Vector3.Distance(WayPoint[count].transform.position, Pos) <2.0f)
        {
            count++;
        }
        if(count >=4)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Bullet")
        {
            Debug.Log("공격성공");

            Destroy(other.gameObject);
            CurrentHp--;
            if(CurrentHp<=0)
            {
                GameManager.instance.Gold++;
                GameManager.instance.textGold.text = GameManager.instance.Gold.ToString();
                Destroy(gameObject);
            }
        }
    }
}