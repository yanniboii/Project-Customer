using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveThrowables : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(timer());
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(5);
        Object.Destroy(this.gameObject);
    }
}
