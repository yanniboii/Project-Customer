using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    GameObject t;
    // Start is called before the first frame update
    void Start()
    {
        t = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(t.transform);
    }
}
