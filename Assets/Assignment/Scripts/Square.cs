using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : Shape
{

    float amountOfShakes;
    float timeBetweenShakes = .1f;

    protected override void onInstantiate()
    {
        force = 7;
    }

    IEnumerator Vibrate()
    {
        
        amountOfShakes = 10;
        while (amountOfShakes > 0)
        {
            base.onClick();
            amountOfShakes--;
            yield return new WaitForSeconds(timeBetweenShakes);
        }

        
    }

    protected override void onClick()
    {

        StartCoroutine(Vibrate());

    }


}
