using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovePlant : MonoBehaviour
{
    public Transform cam;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            if(hit.collider.gameObject.GetComponent<GrowPlantScript>() != null) 
            {
                hit.collider.gameObject.GetComponent<GrowPlantScript>().redGO.SetActive(true);
                hit.collider.gameObject.GetComponent<GrowPlantScript>().fullyGrownGO.SetActive(false);
                Debug.Log("ASDASDA");
                if (Input.GetKey(KeyCode.T))
                {
                    Destroy(hit.collider.gameObject);
                }
            }

        }

    }
}
