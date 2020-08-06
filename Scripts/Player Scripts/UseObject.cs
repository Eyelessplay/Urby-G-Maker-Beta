using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseObject : MonoBehaviour {
    public Transform pickTransform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.collider.gameObject.tag == "pickable")
            {
                if (Input.GetKey(KeyCode.E))
                {
                    SuspendPhysics(hit.collider.gameObject);
                    Debug.DrawLine(ray.origin, hit.point, Color.green);
                    hit.collider.gameObject.transform.SetParent(pickTransform);
                    hit.collider.gameObject.transform.position = pickTransform.position;
                }
                if(Input.GetKey(KeyCode.R))
                {
                    hit.collider.gameObject.transform.SetParent(null);
                    ReactivePhysics(hit.collider.gameObject);
                }
            }
        }
	}

    void SuspendPhysics(GameObject pickedObject)
    {
        Rigidbody rb = pickedObject.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
    void ReactivePhysics(GameObject pickedObject)
    {
        Rigidbody rb = pickedObject.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.None;
    }
}
