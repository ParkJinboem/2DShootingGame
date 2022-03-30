using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target = null;
    float speed = 30;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(target)
        {
            transform.LookAt(target);
        }
        else
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
