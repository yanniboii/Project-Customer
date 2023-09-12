using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGrassUnderPlant : MonoBehaviour
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

    void SpawnPlant()
    {

        // Define the area to paint grass (for example, the center of the terrain)
        int xStart = (int)this.transform.position.x+20;
        int yStart = (int)this.transform.position.z+20;
        int xEnd = (int)this.transform.position.x -20;
        int yEnd = (int)this.transform.position.z-20;

        // Get the detail map (grass map)
        int[,] detailMap = terrainData.GetDetailLayer(0, 0, terrainData.detailWidth, terrainData.detailHeight, 0);

        // Paint grass in the specified area
        for (int x = xStart; x < xEnd; x++)
        {
            for (int y = yStart; y < yEnd; y++)
            {
                // Set a value to indicate grass presence (e.g., 1)
                detailMap[x, y] = 1;
            }
        }

        // Apply the modified detail map back to the terrain data
        terrainData.SetDetailLayer(0, 0, 0, detailMap);

        terrain.Flush();
    }

    void DespawnPlant()
    {
        // Define the area to paint grass (for example, the center of the terrain)
        int xStart = terrainData.detailWidth;
        int yStart = terrainData.detailHeight;
        int xEnd = 3 * terrainData.detailWidth;
        int yEnd = 3 * terrainData.detailHeight;

        // Get the detail map (grass map)
        int[,] detailMap = terrainData.GetDetailLayer(0, 0, terrainData.detailWidth, terrainData.detailHeight, 0);

        // Paint grass in the specified area
        for (int x = xStart; x < xEnd; x++)
        {
            for (int y = yStart; y < yEnd; y++)
            {
                // Set a value to indicate grass presence (e.g., 1)
                detailMap[x, y] = 0;
            }
        }

        // Apply the modified detail map back to the terrain data
        terrainData.SetDetailLayer(0, 0, 0, detailMap);

        terrain.Flush();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            SpawnPlant();
        }
    }
}
