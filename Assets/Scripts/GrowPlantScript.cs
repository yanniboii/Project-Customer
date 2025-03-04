using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] MoneyUI moneyUI;

    private List<Material> growMaterials = new List<Material>();
    private bool fullyGrown = false;
    bool startedGrowing = false;
    private bool hasWater;
    float water;
    private bool hasGivenMoney = false;

    [SerializeField] string plant;

    [SerializeField] WaterUI waterUI;

    [SerializeField] int money;

    public bool isRed;

    AnimalManager animalManager;

    public GameObject fullyGrownGO;
    public GameObject redGO;

    private void Start()
    {
        moneyUI = FindObjectOfType<MoneyUI>();
        animalManager = FindObjectOfType<AnimalManager>();
        for (int i = 0; i < growMeshes.Count; i++)
        {
            for (int j = 0; j < growMeshes[i].materials.Length; j++)
            {
                if (growMeshes[i].materials[j].HasProperty("_Grow"))
                {
                    growMeshes[i].materials[i].SetFloat("_Grow", minGrow);
                    growMaterials.Add(growMeshes[i].materials[j]);
                }
            }
        }
        InvokeRepeating("Red", 0.5f, 0.5f);
    }
    private void Update()
    {
        CheckWater();
    }

    private void Red()
    {
        redGO.SetActive(false);
        if (!fullyGrown)
        {
            fullyGrownGO.SetActive(true);

        }
    }

    public void AddWater(float water)
    {
        this.water += water;
        waterUI.SetWater(this.water);
    }

    void StartGrowing()
    {

        for (int i = 0; i < growMaterials.Count; i++)
        {
            StartCoroutine(GrowPlant(growMaterials[i]));
        }

    }

    void CheckWater()
    {
        if (water > 0)
        {
            if (!startedGrowing)
            {
                Debug.Log("ASDASDASDADADa");
                StartGrowing();
            }
            hasWater = true;
            water -= 0.0001f;
            waterUI.SetWater(this.water);
            startedGrowing = true;
        }
        else
        {
            hasWater = false;
            startedGrowing = false;
        }
    }

    IEnumerator GrowPlant(Material material)
    {
        float growValue = material.GetFloat("_Grow");

        if (!fullyGrown)
        {
            while (growValue < maxGrow)
            {
                //if (hasWater)
                //{
                //healthbar.UpdateHealthbar(hitPoints, maxHitPoints);
                if (hasWater)
                {
                    growValue += 1 / (timeToGrow / refreshRate);
                    material.SetFloat("_Grow", growValue);
                }
                yield return new WaitForSeconds(refreshRate);
                //}

            }
        }
        else
        {

            while (growValue > minGrow)
            {
                //healthbar.UpdateHealthbar(hitPoints, maxHitPoints);

                // growValue -= 1 / (timeToGrow / refreshRate);
                // material.SetFloat("_Grow", growValue);

                yield return new WaitForSeconds(refreshRate);
            }
        }
        if (growValue >= maxGrow)
        {
            fullyGrown = true;
            if (plant == "Fern")
            {
                animalManager.plants[1] += 1;
            }
            else if(plant == "Grass")
            {
                animalManager.plants[0] += 1;
            }
            else if (plant == "Mushroom")
            {
                animalManager.plants[2]         += 1;
            }
            else if (plant == "Berry")
            {
                animalManager.plants[3] += 1;
            }
            else if (plant == "Bramble")
            {
                animalManager.plants[4] += 1;
            }
            else if (plant == "Holly")
            {
                animalManager.plants[5] += 1;
            }
            else if (plant == "Lavender")
            {
                animalManager.plants[6] += 1;
            }
            else if (plant == "Oak")
            {
                animalManager.plants[7] += 1;
            }
            else if (plant == "Ash")
            {
                animalManager.plants[8] += 1;
            }
            else if (plant == "Hazel")
            {
                animalManager.plants[9] += 1;
            }
            else if(plant == "Moss")
            {
                animalManager.plants[10] += 1;
            }
            else if (plant == "Birch")
            {
                animalManager.plants[11] += 1;
            }
            fullyGrownGO.SetActive(false);
            moneyUI.money += money;

        }
        else
        {
            fullyGrown = false;
        }
    }
}
