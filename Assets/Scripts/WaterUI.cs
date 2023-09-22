using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterUI : MonoBehaviour
{
    [SerializeField]Image waterGO;
    [SerializeField] Image noWater;

    public void SetWater(float water)
    {
        if(water > 0)
        {
            waterGO.enabled = true;
            noWater.enabled = false;
        }
        else
        {
            waterGO.enabled =  false;
            noWater.enabled = true;
        }
    }
}
