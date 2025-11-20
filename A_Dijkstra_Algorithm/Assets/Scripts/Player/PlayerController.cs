using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    //private PlayerHealth myHealth;
    private SpriteRenderer mySpr;
    //private Animator myAni;
    

    [Header("Projectile Prefab")]
    //public GameObject atkPrefab;

    [SerializeField] private float attackColdown = 0.3f;
    private Coroutine canATK = null;
    private bool attacking = false;

    [Header("Mouvement")]
    [SerializeField] private float speed = 0f;
    [SerializeField] private float duration = 0f;
    private Coroutine moveC = null;
    private float x = 0f, y = 0f;
    private  Vector2 horizontal = new Vector2(0.5f, -0.25f) , vertical = new Vector2(0.5f, 0.25f);
    private Vector2 velocity = Vector2.zero;
    private Vector2 startPos;

    [Header("Animations")]
    private bool playDeadAnimation;
    //public GameObject boostFX;

    private Player_Controls controls;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //myHealth = GetComponent<PlayerHealth>();
      
        mySpr = GetComponent<SpriteRenderer>();
        //myAni = GetComponent<Animator>();

        startPos = transform.position;
        controls = new Player_Controls();
        controls.Controller.Enable();


        // go back to vector
        controls.Controller.Right.performed += goRight;
        controls.Controller.Left.performed += goLeft;
        controls.Controller.Up.performed += goUp;
        controls.Controller.Down.performed += goDown;
    }

    private void FixedUpdate()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {

        setSprite();

        if (attacking && canATK == null)
        {
            spawnProjectile();
            canATK = StartCoroutine(attackOnColdown());

        }


    }

    private void LateUpdate()
    {
        if (velocity != Vector2.zero && moveC == null)
        {
            moveC = StartCoroutine(Move(velocity));
        }
    }



    private void setSprite()
    {
        /*if (!myHealth.isDead) 
        { 

            playDeadAnimation = false; 
            if (!boostFX.activeSelf) {
                myAni.SetBool("IsDead", myHealth.isDead);
                mySpr.enabled = true;
                boostFX.SetActive(true); 
            } 
        }

        myAni.SetFloat("Direction", velocity.x);


        if (myHealth.isDead && !playDeadAnimation) {
            StartCoroutine(deadControl());
        }*/

    }

    private IEnumerator deadControl()
    {
        //boostFX.SetActive(false);
        //myAni.SetBool("IsDead", myHealth.isDead);
        //myAni.SetTrigger("Explosion");
        playDeadAnimation = true;

        yield return new WaitForSeconds(1f);

        mySpr.enabled = false;
        transform.position = startPos;
        
    }
    private void spawnProjectile()
    {
       // Instantiate(atkPrefab, transform.position, Quaternion.identity, transform.parent);
    }

    private void Mouvement(Vector2 dir)
    {
        //if (myHealth.isDead) { velocity = Vector2.zero; return; }
        //if (velocity == Vector2.zero ) { myRB.linearVelocity = Vector2.zero; return; 

       transform.Translate(dir * speed);

    }

    private IEnumerator Move(Vector2 dir)
    {
        velocity = Vector2.zero;

        Vector2 start = transform.position;
        Vector2 end = transform.position + (Vector3)(dir);
        float t = 0;

        while (t < 1) {
            t += Time.deltaTime / duration;
            transform.position = Vector3.Lerp(start, end, t);
            yield return null;
        }
        moveC = null;
    }

   

    public void goRight(InputAction.CallbackContext context)
    {
        //if(myHealth.isDead) { return; }

        //Mouvement(horizontal);

        if (moveC == null) {
            velocity+= horizontal;
        }

    }

    public void goLeft(InputAction.CallbackContext context)
    {
        //if(myHealth.isDead) { return; }

        //Mouvement(-horizontal);

        if (moveC == null)
        {
            velocity -= horizontal;
        }
    }

    public void goUp(InputAction.CallbackContext context)
    {
        //if(myHealth.isDead) { return; }

        //Mouvement(vertical);

        if (moveC == null)
        {
            velocity += vertical;
        }


    }

    public void goDown(InputAction.CallbackContext context)
    {
        //if(myHealth.isDead) { return; }

        //Mouvement(-vertical);
        if (moveC == null)
        {
            velocity -= vertical;
        }


    }

    public void Attack(InputAction.CallbackContext context) {

        /*if (context.started && !myHealth.isDead)
        {
            attacking = true;
            
        }*/

        if(context.canceled) { attacking = false; }
    }

    private IEnumerator attackOnColdown()
    {
        yield return new WaitForSeconds(attackColdown);
        canATK = null;
    }

  
}
