using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public int currentHealth;

    public void UpdateHealthbar(float currentValue, float maxValue)
    {
        slider.value = (float)(currentValue / maxValue);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
