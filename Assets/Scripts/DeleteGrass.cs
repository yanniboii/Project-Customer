using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteGrass : MonoBehaviour
{
    Terrain terrain;
    TerrainData terrainData;


    // Start is called before the first frame update
    void Start()
    {
        terrain = GetComponentInParent<Terrain>();
        terrainData = terrain.terrainData;
        DespawnPlant();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DespawnPlant()
    {
        int xStart = 0;
        int yStart = 0;
        int xEnd = terrainData.detailWidth;
        int yEnd = terrainData.detailHeight;

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
}
