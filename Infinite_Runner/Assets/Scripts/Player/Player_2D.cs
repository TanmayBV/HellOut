using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2D : MonoBehaviour
{
    [SerializeField] Transform Groundcheck;
    [SerializeField] LayerMask Layer;
    [SerializeField] float speed = 3f;
    [SerializeField] float gravity = 4f;
    [SerializeField] bool clicked;
    
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer sr;

    [SerializeField] private bool isGrounded;

    void Start()
    {
        clicked = true;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
       
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(Groundcheck.position,.5f,Layer);

        if (clicked && isGrounded)
        {
            Up();
        }
        else if (!clicked && isGrounded)
        {
            Down();
        }

       transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    public void toggle()
    {
        clicked = !clicked;
    }

    void Down()
    {
        rb.gravityScale = -gravity;
        sr.flipY = true;
    }

    void Up()
    {
        rb.gravityScale = gravity;
        sr.flipY = false;
    }

}
