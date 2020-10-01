using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject destroyedVersion;

    public float health = 10f;

    public void TakeDamage (float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die ()
    {
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
