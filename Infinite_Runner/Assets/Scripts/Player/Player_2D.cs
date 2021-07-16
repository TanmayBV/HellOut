using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2D : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] float gravity = 4f;
    [SerializeField] bool clicked;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer sr;
    void Start()
    {
        clicked = true;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (clicked)
        {
            Up();
        }
        else if (!clicked)
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
