using UnityEngine;

public class MobEasyController : MonoBehaviour
{
    private Rigidbody2D myRB;
    public MobSpawner spawner;

    [Header("Mouvement")]
    public bool configureSpeed = false;
    [SerializeField] private float speed = 12f;
    private MobHealth myHealth;

   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myHealth = GetComponent<MobHealth>();

        if(!configureSpeed) { speed = Random.Range(30, 36); }
        myRB.linearDamping = speed;
    }

    // Update is called once per frame
    void Update()
    {
        //Speed between 12 - 20
        if (configureSpeed) { myRB.linearDamping = speed; }

        if (myHealth.isDead) { myRB.gravityScale = 0; myRB.linearVelocity = Vector2.zero; }


    }

    private void OnDestroy()
    {
        spawner.removeMob(gameObject);
    }

}
