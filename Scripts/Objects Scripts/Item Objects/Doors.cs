using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Doors : MonoBehaviour {
    private bool rotating = true;
    public bool isActive = false;
    void Start ()
    {
		
	}
	void Update ()
    {
        if (isActive == true)
        {
            if (rotating)
            {
                Vector3 to = new Vector3(0, 90, 0);
                if (Vector3.Distance(transform.rotation.eulerAngles, to) > 0.01f)
                {
                    transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime + .03F);
                }
                else
                {
                    transform.eulerAngles = to;
                    rotating = false;
                }
            }
        }
	}
}
