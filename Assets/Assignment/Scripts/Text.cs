using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : Shape
{

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    protected override void onClick()
    {
        
        rb.AddRelativeForce(new Vector2(Random.Range(-5, 5), Random.Range(-5, 5)), ForceMode2D.Impulse);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
