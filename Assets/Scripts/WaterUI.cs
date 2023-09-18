using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterUI : MonoBehaviour
{
    [SerializeField]Slider slider;

    public void SetWater(float water)
    {
        slider.value = water;
    }
    public void SetMaxWater(float water)
    {
        slider.maxValue = water;
    }
}
