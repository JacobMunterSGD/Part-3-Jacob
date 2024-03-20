using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{

    public Transform obj1;
    public Transform obj2;
    public Transform obj3;

    float interpolation = 0;

    void Start()
    {
        obj1.transform.localScale = new Vector3(0, 0, 0);
        obj2.transform.localScale = new Vector3(0, 0, 0);
        obj3.transform.localScale = new Vector3(0, 0, 0);

        StartCoroutine(growObj1());

    }

    IEnumerator growObj1()
    {

        while (obj1.transform.localScale.x < 1)
        {

            obj1.transform.localScale = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(1, 1, 0), interpolation);
            //new Vector3(obj1.transform.localScale.x + 0.1f, obj1.transform.localScale.y + 0.1f, 0);
            interpolation += .01f;


            yield return null;

        }

        interpolation = 0;
        StartCoroutine(growObj2());
    
    }

    IEnumerator growObj2()
    {

        while (obj2.transform.localScale.x < 1)
        {

            obj2.transform.localScale = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(1, 1, 0), interpolation);
            interpolation += .01f;

            yield return null;

        }

        interpolation = 0;
        StartCoroutine(growObj3());

    }

    IEnumerator growObj3()
    {

        while (obj3.transform.localScale.x < 1)
        {

            obj3.transform.localScale = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(1, 1, 0), interpolation);
            interpolation += .01f;

            yield return null;

        }


    }




}
