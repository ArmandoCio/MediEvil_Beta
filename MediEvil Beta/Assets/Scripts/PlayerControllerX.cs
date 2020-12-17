using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject Magic;

    public float horizontalInput;
    public float speed = 5.0f;

    private GameManager gameManager;
    public GameObject player;

    public AudioClip magicSound;
    private AudioSource audioSource;





    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
            // On spacebar press fire magic
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(Magic, transform.position, Magic.transform.rotation); 
                player.GetComponent<Animator>().Play("Attack1");
                audioSource.PlayOneShot(magicSound, 1.0f);


            }
        }

    }
    private void OnCollisionEnter(Collision other)

    {
        if (other.gameObject.CompareTag("Magic"))
        {


            Destroy(other.gameObject);


        }



    }
}
