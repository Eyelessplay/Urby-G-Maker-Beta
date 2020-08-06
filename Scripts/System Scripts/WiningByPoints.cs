using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WiningByPoints : MonoBehaviour
{
    public GameObject PlayerToCastWin;
    public int PointsToWin;
    private void FixedUpdate()
    {
        if(PlayerToCastWin.GetComponent<PointsSystem>().totalPoints == PointsToWin)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
