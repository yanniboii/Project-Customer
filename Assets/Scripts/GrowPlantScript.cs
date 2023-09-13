using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowPlantScript : MonoBehaviour
{
    public List<MeshRenderer> growMeshes;
    public float timeToGrow = 5f;
    public float refreshRate = 0.05f;
    [Range(0f, 1f)]
    public float minGrow = 0.2f;
    [Range(0f, 1f)]
    public float maxGrow = 1f;

    private List<Material> growMaterials = new List<Material>();
    private bool fullyGrown;
    private bool hasWater;

    private void Start()
    {
        for(int i = 0; i < growMeshes.Count; i++)
        {
            for(int j = 0; j < growMeshes[i].materials.Length; j++)
            {
                if (growMeshes[i].materials[j].HasProperty("_Grow"))
                {
                    growMeshes[i].materials[i].SetFloat("_Grow", minGrow);
                    growMaterials.Add(growMeshes[i].materials[j]);
                }
            }
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            for(int i = 0; i < growMaterials.Count; i++)
            {
                StartCoroutine(GrowPlant(growMaterials[i]));
            }
        }
    }
    
    IEnumerator GrowPlant(Material material)
    {
        float growValue = material.GetFloat("_Grow");

        if(!fullyGrown)
        {
            while(growValue < maxGrow)
            {
                //if (hasWater)
                //{
                    //healthbar.UpdateHealthbar(hitPoints, maxHitPoints);

                    growValue += 1 / (timeToGrow / refreshRate);
                    material.SetFloat("_Grow", growValue);

                    yield return new WaitForSeconds(refreshRate);
                //}

            }
        }
        else
        {
            while (growValue > minGrow)
            {
                //healthbar.UpdateHealthbar(hitPoints, maxHitPoints);

                growValue -= 1 / (timeToGrow / refreshRate);
                material.SetFloat("_Grow", growValue);

                yield return new WaitForSeconds(refreshRate);
            }
        }
        if(growValue >= maxGrow)
        {
            fullyGrown= true;
        }
        else
        {
            fullyGrown= false;
        }
    }
}
