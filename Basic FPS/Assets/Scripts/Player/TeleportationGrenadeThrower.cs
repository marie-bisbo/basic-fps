using UnityEngine;

public class TeleportationGrenadeThrower : MonoBehaviour
{

    public float throwForce = 10f;
    public GameObject grenadePrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            ThrowGrenade();
        }
    }

    void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, transform.position + new Vector3(1f, 1f, 1f), transform.rotation);
        Rigidbody rigidBody = grenade.GetComponent<Rigidbody>();
        rigidBody.AddForce(transform.forward * throwForce);
    }
}
