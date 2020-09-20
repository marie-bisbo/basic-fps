using UnityEngine;

public class TeleportationGrenade : MonoBehaviour
{

    public float detonationDelay = 3f;

    float countdown;
    bool hasDetonated = false;

    // Start is called before the first frame update
    void Start()
    {
        countdown = detonationDelay;
    }

    // Update is called once per frame
    void Update()
    {
        CountDown();
        IsDetonating();
    }

    void CountDown()
    {
        countdown -= Time.deltaTime;
    }

    void IsDetonating()
    {
        if (countdown <= 0f && !hasDetonated)
        {
            Detonate();
            hasDetonated = true;
        }
    }

    void Detonate()
    {
        // Teleport player
        Destroy(gameObject);
    }
}
