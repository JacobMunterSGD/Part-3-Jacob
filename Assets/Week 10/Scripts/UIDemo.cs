using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDemo : MonoBehaviour
{

    public SpriteRenderer sr;
    public Color start;
    public Color end;
    float interpolation;

    public TMP_Dropdown dropdown;

    public void SliderValueHasChanged(Single value)
    {

        interpolation = value;
    
    }

    public void DropDownHasChanged(int index)
    {

        Debug.Log(dropdown.options[index].text);
    
    }

    private void Update()
    {
        sr.color = Color.Lerp(start, end, (interpolation/60));
    }

}
