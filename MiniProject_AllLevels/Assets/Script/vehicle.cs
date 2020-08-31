using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vehicle : MonoBehaviour
{
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        //2.46.31
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-(Vector3.forward) * speed * Time.deltaTime);

        if(transform.position.x <= -1)
        {
            Destroy(gameObject);
        }   
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<Player>() != null)
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene("LoseScene");
        }
    }
}
