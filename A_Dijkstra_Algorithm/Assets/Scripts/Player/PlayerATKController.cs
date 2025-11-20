using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerATKController : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private int damage = 1;
    private Rigidbody2D myRB;
    private Vector2 velocity = Vector2.up;

    private int destroyTimer = 3;
    private bool destroy = false;

    public int MobLayer = 0;

    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        if (MobLayer == 0) { Debug.LogError("Il manque la Layer pour les Mob dans la Zone limite Basse "); }
        StartCoroutine(DestroyTimer());
    }

    private void FixedUpdate()
    {
        myRB.AddForce(velocity * speed);
    }

    private IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(destroyTimer);
        Destroy(this.gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == MobLayer)
        {
            MobHealth temp = collision.gameObject.GetComponent<MobHealth>();
            temp.hurt(damage);
            destroy = true;
        }
    }

    private void LateUpdate()
    {
        if (destroy) {
            Destroy(gameObject);
        }
    }
}
