using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShootBullets : MonoBehaviour
{
    public GameObject Gun;
    public GameObject bulletPrefab;
    public bool isAutomatic=false;
    private float nextTimeFire = 0f;
    public float fireRate = 15f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time >= nextTimeFire && isAutomatic)
        {
            nextTimeFire = Time.time + 1f / fireRate;
            GameObject bulletObject = Instantiate(bulletPrefab);
            bulletObject.transform.position =Gun.transform.position  + Gun.transform.forward;
            bulletObject.transform.forward = Gun.transform.forward;
        }
        else if(Input.GetMouseButtonDown(0) && isAutomatic==false)
        {
            GameObject bulletObject = Instantiate(bulletPrefab);
            bulletObject.transform.position = Gun.transform.position + Gun.transform.forward;
            bulletObject.transform.forward = Gun.transform.forward;
        }
    }
}
