using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LockImageDisable : MonoBehaviour
{
    public void DisableImage()
    {
        Image childImage = GetComponentInChildren<Image>();
        if (childImage != null)
        {
            childImage.enabled = false;
        }
    }
}

