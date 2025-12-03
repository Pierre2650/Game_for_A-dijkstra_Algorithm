using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public int fireLayer = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("sad");
        if (collision.gameObject.layer == fireLayer)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }


    }


}
