using UnityEngine;

public class MobAttack : MonoBehaviour
{
    [Header("Damage")]
    [SerializeField] private int damage = 10;
    public int playerLayer = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if (playerLayer == 0) { Debug.LogError("Il manque la Layer pour le joueur dans les Mob Faciles"); }

    }

    public int GetDamage()
    {
        return damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.layer == playerLayer)
        {
            PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
            health.hurt(damage);
            Destroy(this.gameObject);
        }
    }
}
