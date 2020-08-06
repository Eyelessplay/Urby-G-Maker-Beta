using UnityEngine;

public class Target : MonoBehaviour
{
    public float healt;

    public void TakeDamage(float amount)
    {
        healt -= amount;
        if(healt<=0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if(healt<=0)
        {
            Destroy(gameObject);
        }
    }

}
