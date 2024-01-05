using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private float speed = 5;
    public int playerNum;
    public Animator anim;
    public bool canplay;

    public bool bombBlast;
       // Start is called before the first frame update
    void Start()
    {
        rb.gravityScale = 0;
        anim.SetBool("dead", false);

    }

    // Update is called once per frame

    void Update()
    {
        if (canplay)
        {
            if (rb.velocity.x <= 0)
            {
                rb.transform.localScale = new Vector3(-Mathf.Abs(rb.transform.localScale.x), rb.transform.localScale.y, 0);

            }
            else
            {
                rb.transform.localScale = new Vector3(Mathf.Abs(rb.transform.localScale.x), rb.transform.localScale.y, 0);

            }
        }
        if (bombBlast)
        {
            anim.SetBool("dead", true);
        }
        
    }
    void FixedUpdate()
    {
        if(canplay)
        {
            rb.velocity = new Vector2(joystick.Horizontal * speed, joystick.Vertical * speed);
            //anim.SetTrigger("run");
            if (joystick.Horizontal != 0)
            {
                anim.SetTrigger("run");
            }
            else if (joystick.Vertical != 0)
            {
                anim.SetTrigger("run");
            }
            else
            {
                anim.SetTrigger("idle");
            }
        }
       

    }
}
