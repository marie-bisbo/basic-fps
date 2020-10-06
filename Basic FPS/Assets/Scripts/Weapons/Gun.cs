using UnityEngine;

public class Gun : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCamera;

    public Rigidbody rb;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            DestroyObject(hit);
            HitWithBullet(hit);
        }
    }

    void DestroyObject(RaycastHit hit)
    {
        Target target = hit.transform.GetComponent<Target>();
        if (target != null)
        {
            target.TakeDamage(damage);
        }
    }

    void HitWithBullet(RaycastHit hit)
    {
        if (hit.rigidbody != null)
        {
            hit.rigidbody.AddForceAtPosition(transform.forward * damage, hit.point);
        }
    }
}
