using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] public GameObject movingObj;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float miniSeparationTime;
    [SerializeField] private float maxSeparationTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnVehicle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnVehicle()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(miniSeparationTime, maxSeparationTime));
            GameObject GO = Instantiate(movingObj, spawnPos.position, Quaternion.identity);
            GO.transform.eulerAngles = new Vector3(0, 90, 0);
        }
        
    }
}
