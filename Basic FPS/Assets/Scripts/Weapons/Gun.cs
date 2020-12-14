using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Camera fpsCamera;

    public Rigidbody rb;

    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        if (isReloading)
        {
            return;
        }
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;
    }

    void Shoot()
    {
        Debug.Log("Kapow");
        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            DestroyObject(hit);
            HitWithBullet(hit);
        }
        currentAmmo--;
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
