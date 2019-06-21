using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Transform bandit;
    public float waveInterval;
    float nextWave;
    int enemiesInWave, score;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextWave)
        {
          nextWave = Time.time + waveInterval;
          enemiesInWave = Random.Range(1, 3);
          for (int i = 0; i < enemiesInWave; i++)
          {
            Instantiate(bandit, new Vector3(10f, 0, 0), Quaternion.identity);
          }
        }

        scoreText.text = score.ToString();
    }

    public void addScore(int addToScore)
    {
      score += addToScore;
    }
}
