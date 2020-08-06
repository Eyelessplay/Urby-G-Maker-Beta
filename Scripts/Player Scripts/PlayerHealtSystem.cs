using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealtSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealt = 100;
    public int currentHealt;

    public HealtBar healtBar;
    void Start()
    {
        currentHealt = maxHealt;
        healtBar.SetMaxHealt(maxHealt);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealt<=0)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("WinScene");
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Damage" || other.gameObject.tag=="Bullet")
        {
            TakeDamage(20);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Damage Constant")
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealt -= damage;

        healtBar.SetHealt(currentHealt);
    }
}
