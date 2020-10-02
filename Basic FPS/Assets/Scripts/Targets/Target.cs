using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject destroyedVersion;

    public float health = 10f;

    public float explosionForce = 500f;

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
        GameObject destroyedObject = Instantiate(destroyedVersion, transform.position, transform.rotation);
        Rigidbody[] allRigidBodies = destroyedObject.GetComponentsInChildren<Rigidbody>();
        if (allRigidBodies.Length > 0)
        {
            foreach(var body in allRigidBodies)
            {
                body.AddExplosionForce(explosionForce, transform.position, 1);
            }
        }
        Destroy(gameObject);
    }
}
