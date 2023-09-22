using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovePlant : MonoBehaviour
{
    public Transform cam;
    ThrowableSeeds throwableSeeds;
    GetWater getWater;
    [SerializeField] GameObject shovel;
    [SerializeField] Transform equipTransform;
    MessageUI messageUI;

    GameObject shovelLocal;

    public bool hasShovel;
    // Start is called before the first frame update
    void Start()
    {
        messageUI = FindObjectOfType<MessageUI>();
        throwableSeeds = FindObjectOfType<ThrowableSeeds>();
        getWater = FindObjectOfType<GetWater>();
    }

    public void DestroyShovel()
    {
        throwableSeeds.enabled = true;
        Destroy(shovelLocal);
        hasShovel = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (hasShovel)
            {
                throwableSeeds.enabled = true;
                Destroy(shovelLocal);
                hasShovel = false;
            }
            else
            {
                if(messageUI.messageIndex == 6)
                {
                    messageUI.messageIndex++;
                    messageUI.SetNewMessage();
                }
                getWater.DestroyWateringCan();
                throwableSeeds.enabled = false;
                shovelLocal = Instantiate(shovel, equipTransform);
                hasShovel = true;
            }
        }

        if (hasShovel)
        {
            if (Physics.Raycast(cam.position, cam.forward, out hit, 500f))
            {
                if (hit.collider.gameObject.GetComponent<GrowPlantScript>() != null)
                {
                    hit.collider.gameObject.GetComponent<GrowPlantScript>().redGO.SetActive(true);
                    hit.collider.gameObject.GetComponent<GrowPlantScript>().fullyGrownGO.SetActive(false);
                    Debug.Log("ASDASDA");
                    if (Input.GetKey(KeyCode.Mouse0))
                    {
                        Destroy(hit.collider.gameObject);
                    }
                }

            }

        }

    }



}

