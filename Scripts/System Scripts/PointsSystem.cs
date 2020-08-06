using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PointsSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public Text pointsText;
    public int totalPoints;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="point")
        {
            totalPoints=totalPoints + other.gameObject.GetComponent<PointItem>().pointsValue;
            pointsText.text = totalPoints.ToString();
            Debug.Log(totalPoints);
            other.gameObject.SetActive(false);
        }
    }
}
