using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject destroyedVersion;

    public float health = 10f;

    public float explosionForce = 100f;

    public void TakeDamage (float amount)
    {
        health -= amount;
        if (health <= 0 && transform.localScale.x > 1f)
        {
            Multiply();
        }
        else
        {
            StartCoroutine(ScaleOverTime(2));
        }
    }

    void Multiply ()
    {
        GameObject cube1 = Instantiate(gameObject, transform.position + new Vector3(5f, 0f), transform.rotation);
        GameObject cube2 = Instantiate(gameObject, transform.position + new Vector3(-5f, 0f), transform.rotation);
        cube1.transform.localScale *= 0.5f;
        cube2.transform.localScale *= 0.5f;
        Destroy(gameObject);
    }

    IEnumerator ScaleOverTime(float time)
    {
        Vector3 originalScale = gameObject.transform.localScale;
        Vector3 destinationScale = new Vector3(2.0f, 2.0f, 2.0f);

        float currentTime = 0.0f;

        do
        {
            gameObject.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);

        Die();
    }

    void Die ()
    {
        GameObject destroyedObject = Instantiate(destroyedVersion, transform.position, transform.rotation);
        Rigidbody[] allRigidBodies = destroyedObject.GetComponentsInChildren<Rigidbody>();
        if (allRigidBodies.Length > 0)
        {
            foreach (var body in allRigidBodies)
            {
                body.AddExplosionForce(explosionForce, transform.position, 1);
            }
        }
        Destroy(gameObject);
    }
}
