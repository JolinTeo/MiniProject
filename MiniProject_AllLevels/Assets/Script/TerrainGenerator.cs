using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private int minDistanceFromPlayer;
    [SerializeField] private int maxTerrianCount;
    [SerializeField] private List<TerrainData> terrainDatas= new List<TerrainData>();
    [SerializeField] private Transform terrainHolder;

    private List<GameObject> currentTerrains = new List<GameObject>();
    public Vector3 currentPosition = new Vector3(0, 0, 0);

    //1.40.39

    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < maxTerrianCount; i++)
        {
            //create terrains at currentPosition
            //Increment at z-axis
            SpawnTerrain(true, new Vector3(0,0,0));
        }
        maxTerrianCount = currentTerrains.Count;
    }

    // Update is called once per frame

    public void SpawnTerrain(bool isStart, Vector3 playerPos)
    {
        if((currentPosition.z - playerPos.z < minDistanceFromPlayer) || (isStart))
        {
            //which terrain will be spawned
            int whichTerrain = Random.Range(0, terrainDatas.Count);
            //how many will be spawned
            int terrainInSuccession = Random.Range(1, terrainDatas[whichTerrain].maxInSuccession);

            for (int i = 0; i < terrainInSuccession; i++)
            {
                GameObject terrain = Instantiate(terrainDatas[whichTerrain].possibleTerrain[Random.Range(0, terrainDatas[whichTerrain].possibleTerrain.Count)], currentPosition, Quaternion.identity, terrainHolder);
                currentTerrains.Add(terrain);
                if (!isStart)
                {
                    if (currentTerrains.Count > maxTerrianCount)
                    { 
                        Destroy(currentTerrains[0]);
                        currentTerrains.RemoveAt(0);
                    }
                }
                currentPosition.z++;
            }
        }
    }
}
