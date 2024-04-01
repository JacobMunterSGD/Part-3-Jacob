using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class Shape : MonoBehaviour
{
    public float force = 10;
    public Rigidbody2D rb;
    public SpriteRenderer sr;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        Vector2 tempForce = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
        rb.AddRelativeForce(tempForce, ForceMode2D.Impulse);

        //StartCoroutine(moveUpdate());
        onInstantiate();

    }

    private void OnMouseDown()
    {

        onClick();

    }

    protected virtual void onInstantiate()
    {
        
    }

    protected virtual void onClick()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, Random.Range(0, 360));
        rb.AddRelativeForce(new Vector2(force, 0), ForceMode2D.Impulse);
    }

    IEnumerator moveUpdate()
    {

        onClick();

        yield return new WaitForSeconds(10);
        StartCoroutine(moveUpdate());
    
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {

        GameManager.growShrinkShape(gameObject);
    }

}
