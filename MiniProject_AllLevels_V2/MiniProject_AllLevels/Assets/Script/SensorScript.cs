using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorScript : MonoBehaviour
{
    public GameObject obstacle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay (Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            obstacle = other.gameObject;
        }
        else
        {
            obstacle = null;
        }
    }

    public void OnTriggerExit (Collider other)
    {
        obstacle = null;
    }
}
