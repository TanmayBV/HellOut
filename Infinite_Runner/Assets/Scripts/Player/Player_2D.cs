using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Player_2D : MonoBehaviour
{
    public new AudioSource audio;
    [SerializeField] Transform Groundcheck;
    [SerializeField] LayerMask Layer;
    public float speed = 3f;
    [SerializeField] float gravity = 4f;
    [SerializeField] bool clicked;
    
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] GameObject EndPanal;
    [SerializeField] private bool isGrounded;
    public AdsManager Ads;

    
    void Start()
    {
       
        clicked = true;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        Ads = FindObjectOfType<AdsManager>();

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(Groundcheck.position,.8f,Layer);

        if (clicked && isGrounded)
        {
            Up();
        }
        else if (!clicked && isGrounded)
        {
            Down();
        }

        if (1<PlayerPrefs.GetInt("Trys",0))
        {
            Debug.Log("s");
        }

        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    public void toggle()
    {
        audio.Play();
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

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.collider.tag == "Traps")
        {
            gameObject.SetActive(false);
            EndPanal.SetActive(true);
            Time.timeScale = 0;
            Ads.lives += 1+PlayerPrefs.GetInt("tries",0);
            Ads.ShowBanner();
        }
        else
        {
            Ads.Hidebaner();
        }
	}
}
