using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGrassUnderPlant : MonoBehaviour
{

    Terrain terrain;
    TerrainData terrainData;

    [SerializeField] float grassSpawnRadius;
    [SerializeField] int grassDensity;

    // Start is called before the first frame update
    void Start()
    {
        terrain = GetComponentInParent<Terrain>();
        terrainData = terrain.terrainData;
        // Arda was here 
        //DespawnPlant();
        SpawnPlant();
    }

    void SpawnPlant()
    {

        Vector3 terrainLocalPos = transform.position - terrain.transform.position;


        int terrainX = Mathf.Clamp(Mathf.FloorToInt(terrainLocalPos.x / terrainData.size.x * terrainData.detailWidth), 0, terrainData.detailWidth - 1);
        int terrainY = Mathf.Clamp(Mathf.FloorToInt(terrainLocalPos.z / terrainData.size.z * terrainData.detailHeight), 0, terrainData.detailHeight - 1);



        int[,] detailMap = terrainData.GetDetailLayer(0, 0, terrainData.detailWidth, terrainData.detailHeight, 0);

        for (int x = terrainX - (int)grassSpawnRadius; x <= terrainX + grassSpawnRadius; x++)
        {
            for (int y = terrainY - (int)grassSpawnRadius; y <=terrainY + grassSpawnRadius; y++)
            {
                if(Vector2.Distance(new Vector2(x, y), new Vector2(terrainX, terrainY)) <= grassSpawnRadius)
                {
                    detailMap[y,x] = grassDensity;
                }
            }
        }

        terrainData.SetDetailLayer(0, 0, 0, detailMap);

        terrain.Flush();
    }

    void DespawnPlant()
    {
        int xStart = 0;
        int yStart = 0;
        int xEnd =  terrainData.detailWidth;
        int yEnd =  terrainData.detailHeight;

        int[,] detailMap = terrainData.GetDetailLayer(0, 0, terrainData.detailWidth, terrainData.detailHeight, 0);

        for (int x = xStart; x < xEnd; x++)
        {
            for (int y = yStart; y < yEnd; y++)
            {
                detailMap[x, y] = 0;
            }
        }

        terrainData.SetDetailLayer(0, 0, 0, detailMap);

        terrain.Flush();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            //SpawnPlant();
        }
    }
}
