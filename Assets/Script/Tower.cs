using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject Bullet;
    public Transform FirePos;
    float currentTime;
    float attackRange = 15.0f;
    Transform towerTarget;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        float short_dis = attackRange;

        towerTarget = null;
        for(int i=0; i<enemy.Length; i++)
        {
            float dis = Vector3.Distance(transform.position, enemy[i].transform.position);
            if(dis<short_dis)
            {
                towerTarget = enemy[i].transform;
            }
        }
        if(towerTarget !=null)
        {
            if(currentTime>=1.0f)
            {
                GameObject temp = Instantiate(Bullet, FirePos.transform.position, FirePos.rotation);
                temp.GetComponent<Bullet>().target = towerTarget;
                currentTime = 0;
            }
            dir = towerTarget.transform.position - transform.position;
            dir = dir.normalized;
            transform.rotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        }
    }
}
