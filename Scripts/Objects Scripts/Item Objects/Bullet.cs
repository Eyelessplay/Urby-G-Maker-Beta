using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    public float lifeTime = 2f;
    public int bulletDamage;
    private float lifeTimer;
    public String [] customTarget;
    void Start()
    {
        lifeTimer = lifeTime;
        
    }

   
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        lifeTimer -= Time.deltaTime;
        if(lifeTimer<=0f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag== customTarget[0] || collision.gameObject.tag==customTarget[1])
        {
            
            collision.gameObject.GetComponent<Target>().healt = collision.gameObject.GetComponent<Target>().healt - bulletDamage;
            
        }
    }
}
