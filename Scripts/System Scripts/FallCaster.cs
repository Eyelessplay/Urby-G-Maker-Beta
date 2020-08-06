using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCaster : MonoBehaviour
{
    [SerializeField] Transform targetSpawn;
    [SerializeField] GameObject player;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entre a la caida");
        if (other.gameObject.tag == "Player")
        {
            player.transform.position = targetSpawn.transform.position;
        }
    }
   
}
