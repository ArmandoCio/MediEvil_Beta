using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
   
{
    public GameObject StartScreen;
    public List<GameObject> Enemy;
    private float spawnrate = 2.0f;

    private float spawnLimitXLeft = 7;
    private float spawnLimitXRight = 1;
    private float spawnPosY = 1;

    public int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameoverText;
    

    public bool isGameActive;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver() 
    {
        isGameActive = false;
        gameoverText.gameObject.SetActive(true);


    }
    

    IEnumerator spawnEnemy() {
        while(isGameActive){
            yield return new WaitForSeconds(spawnrate);
            int enemyIndex = Random.Range(0, Enemy.Count);
            Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
            Instantiate(Enemy[enemyIndex], spawnPos, Enemy[enemyIndex].transform.rotation);
            yield return new WaitForSeconds(spawnrate);

        }
    }

    public void UpdateScore(int scoreToAdd) {
        score += scoreToAdd;
        scoreText.text = "Score : " + score;

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void easyMode()
    {
        isGameActive = true;
        StartCoroutine(spawnEnemy());
        score = 0;
        UpdateScore(0);
        StartScreen.gameObject.SetActive(false);

    }

    public void medMode()
    {
        isGameActive = true;
        spawnrate = 1.5f;
        StartCoroutine(spawnEnemy());
        score = 0;
        UpdateScore(0);
        StartScreen.gameObject.SetActive(false);

    }

    public void hardMode()
    {
        isGameActive = true;
        spawnrate = 1.0f;
        StartCoroutine(spawnEnemy());
        score = 0;
        UpdateScore(0);
        StartScreen.gameObject.SetActive(false);

    }



}
