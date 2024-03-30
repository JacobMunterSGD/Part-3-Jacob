using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Triangle : Shape
{

    float timeToSwitch;
    float red = 1;
    float green = 0;
    float blue = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 currentColour = new Vector3(sr.color.r, sr.color.g, sr.color.b);

        //float test = collision.gameObject.TryGetComponent<GameObject>(out force force)
        
    }

    IEnumerator ChangeColour()
    {
        Color currentColour = new Color(sr.color.r, sr.color.g, sr.color.b);
        timeToSwitch = 4;
        while (timeToSwitch > 0)
        {
            currentColour = new Color(red, green, blue, 1);
            sr.color = currentColour;
            
            red += Random.Range(-0.001f, -0.0005f);
            green += Random.Range(0.0001f, 0.001f);
            blue += Random.Range(0.0001f, 0.001f);

            timeToSwitch -= Time.deltaTime;
            yield return null;
        }
    }

    protected override void onClick()
    {

        StartCoroutine(ChangeColour());

    }

}
