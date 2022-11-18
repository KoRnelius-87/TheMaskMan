using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void MaxLife(float maxlife)
    {
        slider.maxValue = maxlife;
    }

    public void changeLife(float ActualLife)
    {
        slider.value = ActualLife;
    }

    public void StartBar(float Life)
    {
        MaxLife(Life);
        changeLife(Life);
    }
}
