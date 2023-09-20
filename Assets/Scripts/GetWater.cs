using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWater : MonoBehaviour
{
    public Transform cam;
    [SerializeField] WaterUI waterUI;
    [SerializeField] GameObject wateringCan;
    [SerializeField] Transform equipTransform;
    ThrowableSeeds throwableSeeds;
    RemovePlant removePlant;

    MessageUI messageUI;

    GameObject waterCan;


    public bool hasWateringCan = false;

    float water;
    // Start is called before the first frame update
    void Start()
    {
        messageUI = FindObjectOfType<MessageUI>();
        throwableSeeds= FindObjectOfType<ThrowableSeeds>();
        removePlant = FindObjectOfType<RemovePlant>();
        throwableSeeds.enabled = false;
    }

    public void DestroyWateringCan()
    {
        throwableSeeds.enabled = true;
        Destroy(waterCan);
        hasWateringCan = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.R))
        {
            if(hasWateringCan)
            {
                throwableSeeds.enabled = true;
                Destroy(waterCan);
                hasWateringCan = false;
            }
            else
            {
                if(messageUI.messageIndex == 2)
                {
                    messageUI.messageIndex++;
                    messageUI.SetNewMessage();
                }
                removePlant.DestroyShovel();
                throwableSeeds.enabled = false;
                waterCan = Instantiate(wateringCan, equipTransform);
                hasWateringCan = true;
            }
        }


        if (Input.GetKey(KeyCode.Mouse0) && hasWateringCan)
        {
            if (Physics.Raycast(cam.position, cam.forward, out hit, 500f))
            {

                if (water <= 1)
                {
                    if (hit.collider.CompareTag("Water"))
                    {
                        if (messageUI.messageIndex == 3)
                        {
                            messageUI.messageIndex++;
                            messageUI.SetNewMessage();
                        }
                        Debug.Log(water);
                        water += 0.001f;
                        waterUI.SetWater(water);
                    }
                }
                if (water > 0f)
                {
                    if (hit.collider.CompareTag("Plant"))
                    {
                        if (messageUI.messageIndex == 4)
                        {
                            messageUI.messageIndex++;
                            messageUI.SetNewMessage();
                        }
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

