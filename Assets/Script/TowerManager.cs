using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    Ray ray;
    RaycastHit hitInfo;

    public GameObject Tower;
    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out hitInfo))
            {
                if(hitInfo.transform.tag.Equals("Map") && GameManager.instance.Gold > 0)
                {
                    GameManager.instance.Gold--;
                    Instantiate(Tower, hitInfo.transform.position + new Vector3(1,2,-1), Quaternion.identity);
                    hitInfo.transform.tag = "Finish";
                }
            }
        }
    }
}
