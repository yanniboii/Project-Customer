using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWater : MonoBehaviour
{
    public Transform cam;
    [SerializeField] WaterUI waterUI;

    float water;
    // Start is called before the first frame update
    void Start()
    {
        waterUI = FindObjectOfType<WaterUI>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Input.GetKey(KeyCode.R))
        {
            if (Physics.Raycast(cam.position, cam.forward, out hit, 500f))
            {
                if (water <= 1)
                {
                    if (hit.collider.CompareTag("Water"))
                    {
                        Debug.Log(water);
                        water += 0.001f;
                        waterUI.SetWater(water);
                    }
                }
                if (water > 0f)
                {
                    if (hit.collider.CompareTag("Plant"))
                    {
                        Debug.Log("Plant");
                        water -= 0.001f;
                        waterUI.SetWater(water);
                        hit.collider.GetComponent<GrowPlantScript>().AddWater(0.001f);
                    }
                }
            }
        }

    }
}
