using UnityEngine;

public class PlayerBaseController : MonoBehaviour
{
    public int MobLayer = 0;
    public PlayerHealth PlayerHealth;

    private void Start()
    {
        if (MobLayer == 0) { Debug.LogError("Il manque la Layer pour les Mob dans la Zone limite Basse "); }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == MobLayer)
        {
            MobAttack temp = collision.gameObject.GetComponent<MobAttack>();
            PlayerHealth.hurt(temp.GetDamage());
            Destroy(collision.gameObject);

        }
        else
        {
            Debug.LogError("Il manque la Layer pour les Mob dans la Zone limite Basse ou dans les mobs ");
        }
    }
}
