using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{
    private GameManager gameManager;
    public ParticleSystem explosion;



    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }


    private void OnTriggerEnter(Collider other)

    {
        if (other.gameObject.CompareTag("Magic"))
        {

            explosion.Play(true);
            Debug.Log(explosion + "Played");
            Destroy(gameObject);
            Destroy(other.gameObject);
            gameManager.UpdateScore(35);



        }




    }
}
