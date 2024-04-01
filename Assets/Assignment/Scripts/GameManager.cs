using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public List<GameObject> shapes = new List<GameObject>();

    public static float numberOfShapes = 0;

    public GameObject button;

    public TMP_Text shapeText;

    public void startGame()
    {
        button.SetActive(false);
        StartCoroutine(MakeShape());
    }


    IEnumerator MakeShape()
    {
        int temp = (Random.Range(0, shapes.Count));
        Instantiate(shapes[temp]);

        numberOfShapes++;
        
        yield return new WaitForSeconds(1);
        StartCoroutine(MakeShape());
    }

    public void UpdateShapeText()
    {

        shapeText.text = "Shapes: " + numberOfShapes;
    
    }

    private void Update()
    {
        UpdateShapeText();
    }

    public static void growShrinkShape(GameObject go)
    {
        float growBy = Random.Range(-.2f, .2f);
        go.transform.localScale = new Vector3(go.transform.localScale.x + growBy, go.transform.localScale.y + growBy, go.transform.localScale.z + growBy);
        if (go.transform.localScale.x < 0)
        {
            numberOfShapes--;
            Destroy(go);   
        }
        

    }


}
