using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RuntimeTerainGenerator : MonoBehaviour {

    //The higher the numbers, the more hills/mountains there are
    private float HM; //= Random.Range(0, 1);

    //The lower the numbers in the number range, the higher the hills/mountains will be...
    private float divRange;// = Random.Range(1,1);
    private NavMeshSurface TerrrainNavMesh;
    private Terrain terrain;
 
    private void OnEnable()
    {
        HM = Random.Range(2, 10);
        divRange = Random.Range(10, 15);
        TerrrainNavMesh = GetComponent<NavMeshSurface> ();
        terrain = GameObject.FindGameObjectWithTag("Ground").GetComponent<Terrain>();
        GenerateTerrain(terrain,HM);
    }

    //Our Generate Terrain function
    public void GenerateTerrain(Terrain t, float tileSize)
    {
        //Heights For Our Hills/Mountains
        float[,] hts = new float[t.terrainData.heightmapWidth, t.terrainData.heightmapHeight];
        for (int i = 0; i < t.terrainData.heightmapWidth; i++)
        {
            for (int k = 0; k < t.terrainData.heightmapHeight; k++)
            {
                hts[i, k] = Mathf.PerlinNoise(((float)i / (float)t.terrainData.heightmapWidth) * tileSize, ((float)k / (float)t.terrainData.heightmapHeight) * tileSize) / divRange;
            }
        }
        Debug.LogWarning("DivRange: " + divRange + " , " + "HTiling: " + HM);
        t.terrainData.SetHeights(0, 0, hts);
        TerrrainNavMesh.BuildNavMesh();
    }
}
