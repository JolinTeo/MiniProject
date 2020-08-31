using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] public TerrainGenerator terrainGenerator;
    [SerializeField] private Text scoreText;
    [SerializeField]
    private int Score;
    private Animator animator;
    private bool isHopping;

    public GameObject player;

    public SensorScript []box;


    private void Start()
    {
        animator = GetComponent<Animator>();

        Score = 0;
    }

    private void Update()
    {
        if(/*Score >= 300*/SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level1") && Score == 300)
        {
            SceneManager.LoadScene("Level2");
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level2") && Score == 400)
        {
            SceneManager.LoadScene("WinScene");
        }

        scoreText.text = "Score : " + Score;

        if (Input.GetKeyDown(KeyCode.W) && !isHopping && box[0].obstacle == null)
        {
            Score += 10;
           
            float xDifference = 0;
            if(transform.position.x % 1 == 0)
            {
                xDifference = Mathf.Round(transform.position.x) - transform.position.x;                
            }
            MoveCharacter(new Vector3(xDifference, 0, 1));
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        
        else if(Input.GetKeyDown(KeyCode.A) && !isHopping && box[2].obstacle == null)
        {
            MoveCharacter(new Vector3(-1, 0, 0));
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        else if (Input.GetKeyDown(KeyCode.D) && !isHopping && box[1].obstacle == null)
        {
            MoveCharacter(new Vector3(1, 0, 0));
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }

        else if (Input.GetKeyDown(KeyCode.S) && !isHopping && box[3].obstacle == null)
        {
            MoveCharacter(new Vector3(0, 0, -1));
            transform.rotation = Quaternion.Euler(0, 360, 0);
            Score -= 10;
        }
    }

    private void MoveCharacter(Vector3 difference)
    {
        animator.SetTrigger("Hop");
        isHopping = true;
        transform.position = (transform.position + difference);
        terrainGenerator.SpawnTerrain(false, transform.position);
    }

    public void FinishHop()
    {
        isHopping = false;
    }

    public void OnCollisionEnter (Collision collision)
    {
        print("Collision");
    }

}
