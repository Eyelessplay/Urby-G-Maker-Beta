using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Interaction : MonoBehaviour {

    public Text interactionMessage;

	void Start () {
		
	}
	
	
	void Update ()
    {
		
	}

    private void OnTriggerStay(Collider other)
    {
       
        if (other.gameObject.tag != "Item" && other.gameObject.tag!= "platform" && other.gameObject.tag != "Fall Caster")
        {
            interactionMessage.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                other.gameObject.GetComponent<SwitchController>().ActiveSwitch(); 
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        interactionMessage.gameObject.SetActive(false);
    }

}
