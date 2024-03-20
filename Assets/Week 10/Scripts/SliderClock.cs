using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderClock : MonoBehaviour
{

    Slider slider;
    float timer;
    public float speed;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {

        timer += Time.deltaTime * speed;
        timer = timer % 60;
        slider.value = timer;

    }
}
