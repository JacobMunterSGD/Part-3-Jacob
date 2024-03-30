using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<GameObject> shapes = new List<GameObject>();

    public GameObject circle;

    void Start()
    {
        StartCoroutine(MakeShape());
    }


    IEnumerator MakeShape()
    {
        int temp = (Random.Range(0, shapes.Count));
        Instantiate(shapes[temp]);
        yield return new WaitForSeconds(1);
        StartCoroutine(MakeShape());
    
    }


}
