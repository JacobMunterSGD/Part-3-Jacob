using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlightControl : MonoBehaviour
{
    public GameObject missile;
    public float speed = 5;
    public float turningSpeedReduction = 0.75f;
    Coroutine coroutine;
    float timeOnMoveForwards = 10;
    float newInterpolation = 0;
    float toTurnBy;
    Quaternion currentHeading;
    Quaternion newHeading;

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            timeOnMoveForwards = 0;
            newInterpolation = 1;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            newInterpolation = 0;
            timeOnMoveForwards = 1;
            toTurnBy = 50;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            newInterpolation = 0;
            timeOnMoveForwards = 1;
            toTurnBy = -50;

        }

        newMoveForwards(1);
        newMakeTurn(toTurnBy);

    }

    void newMoveForwards(float length)
    {
        if (timeOnMoveForwards < length)
        {
            timeOnMoveForwards += Time.deltaTime;
            missile.transform.Translate(transform.right * speed * Time.deltaTime);
        }
        
    }

    void newMakeTurn(float turn)
    { 

        if (newInterpolation == 0)
        {
            currentHeading = missile.transform.rotation;
            newHeading = currentHeading * Quaternion.Euler(0, 0, turn);
        }
        
        if (newInterpolation < 1)
        {
            newInterpolation += Time.deltaTime;
            missile.transform.rotation = Quaternion.Lerp(currentHeading, newHeading, newInterpolation);
            missile.transform.Translate(transform.right * (speed * turningSpeedReduction) * Time.deltaTime);
        }


    }
    

    public void MakeTurn(float turn)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(Turn(turn));
    }

    public void MoveForwards(float length)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(RunLeg(length));
    }

    IEnumerator RunLeg(float legLength)
    {
        float time = 0;
        while (time < legLength)
        {
            time += Time.deltaTime;
            missile.transform.Translate(transform.right * speed * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator Turn(float turn)
    {
        float interpolation = 0;
        Quaternion currentHeading = missile.transform.rotation;
        Quaternion newHeading = currentHeading * Quaternion.Euler(0, 0, turn);
        while (interpolation < 1)
        {
            interpolation += Time.deltaTime;
            missile.transform.rotation = Quaternion.Lerp(currentHeading, newHeading, interpolation);
            missile.transform.Translate(transform.right * (speed * turningSpeedReduction) * Time.deltaTime);
            yield return null;
        }
    }
}
