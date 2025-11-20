using UnityEngine;

public class Parallax_Part : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    private Vector2 velocity = Vector2.down;


    // Update is called once per frame
    void Update()
    {

        transform.Translate(velocity * speed * Time.deltaTime);

        if(transform.position.y <= -10.2)
        {
            transform.position = new Vector2(0, 10.2f);
        }
    }
}
