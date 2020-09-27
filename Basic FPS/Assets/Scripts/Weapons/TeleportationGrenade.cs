using UnityEngine;

public class TeleportationGrenade : MonoBehaviour
{

    public float detonationDelay = 3f;

    float countdown;
    bool hasDetonated = false;

    private PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        countdown = detonationDelay;
    }

    public void Awake()
    {
        player = Object.FindObjectOfType<PlayerMovement>();
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
        player.Teleport(transform.position);
        Destroy(gameObject);
    }
}
