using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsEnemy : MonoBehaviour
{
    private float leftLimit = -11f;
    private GameManager gameManager;

    public AudioClip gameOverSound;
    private AudioSource audioSource;



    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
        // Destroy enemy if past z position
        if (transform.position.z < leftLimit)
        {
            audioSource.PlayOneShot(gameOverSound, 1.0f);
            gameManager.GameOver();
            Destroy(gameObject,1.0f);



        }

    }
}
