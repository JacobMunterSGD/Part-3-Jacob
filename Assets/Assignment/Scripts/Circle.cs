using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : Shape
{

    bool isGrowing = false;
    float maxSize = 2;
    IEnumerator coroutineToStop;

    protected override void onInstantiate()
    {
        coroutineToStop = Shrink();
    }

    IEnumerator Grow()
    {
        isGrowing = true;
        float size = transform.localScale.x;
        while (size < maxSize)
        {
            size += Time.deltaTime;
            transform.localScale = new Vector3(size, size, size);
            yield return null;
        }

    }

    IEnumerator Shrink()
    {
        isGrowing = false;
        float size = transform.localScale.x;
        while (size > 0)
        {
            size -= Time.deltaTime;
            transform.localScale = new Vector3(size, size, size); ;
            yield return null;
        }
        Destroy(gameObject);

    }

    protected override void onClick()
    {

        if (!isGrowing)
        {
            StopCoroutine(coroutineToStop);
            coroutineToStop = Grow();
            StartCoroutine(coroutineToStop);
        }
        else if (isGrowing)
        {
            StopCoroutine(coroutineToStop);
            coroutineToStop = Shrink();
            StartCoroutine(coroutineToStop);
        }

    }

}
