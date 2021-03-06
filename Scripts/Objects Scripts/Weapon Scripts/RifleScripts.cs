﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleScripts : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 15f;

    public Camera fpsCam;
    //public ParticleSystem FireShoot;
    //public GameObject impactEffect;

    private float nextTimeFire = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >= nextTimeFire)
        {
            nextTimeFire = Time.time + 1f / fireRate;
            Shoot();
        }
        
    }

    void Shoot()
    {
        //FireShoot.Play();
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward,out hit,range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if(target !=null)
            {
                target.TakeDamage(damage);
            }

            if(hit.rigidbody !=null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            //GameObject impactGO =Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            //Destroy(impactGO, 2f);
        }
    }
}
