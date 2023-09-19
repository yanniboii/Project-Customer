using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadgeUI : MonoBehaviour
{
    [SerializeField] Image image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAlpha(float alpha)
    {
        if(alpha > 255)
        {
            alpha = 255;
        }
        if(alpha < 0)
        {
            alpha = 0;
        }
        image.color = new Color(image.color.r,image.color.g,image.color.b,alpha);
    }
}
