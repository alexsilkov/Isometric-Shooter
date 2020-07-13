using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject enemyPrefab;
    public Text message;
    public Text waveNumber;
    public Canvas resultCanvas;
    
   
    public int waveEnemyCount = 5; // Число врагов для волны
    public int maxWaveCount = 3; // Максимальное колличество волн врагов

    private int currentEnemyCount = 0; // Текущее количество врагов
    private int currentWaveNumber = 0; // Текущая волна врагов

    void Start()
    {
        currentWaveNumber = 1;
        StartCoroutine(Spawn(waveEnemyCount));
        currentEnemyCount = waveEnemyCount;
        waveNumber.text = "Wave " + currentWaveNumber.ToString();
    }

    public void WaveCheck()
    {
        currentEnemyCount--;
        if (currentWaveNumber != maxWaveCount && currentEnemyCount==0)
        {
            currentWaveNumber++;
            waveEnemyCount += 5; //Простая формула, увеличивающая количество зомби
            StartCoroutine(Spawn(waveEnemyCount));
            currentEnemyCount = waveEnemyCount;
            waveNumber.text = "Wave " + currentWaveNumber;
        }
        else if (currentWaveNumber == maxWaveCount && currentEnemyCount==0)
        {
            message.text = "Победа!";
            Time.timeScale = 0f;
            resultCanvas.gameObject.SetActive(true);
        }
    }

    IEnumerator Spawn(int enemy)
    {
        for (int i = 0; i < enemy; i++)
        {
            int number = Random.Range(0, spawnPoints.Length);
            Instantiate(enemyPrefab, spawnPoints[number].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(3.0f);
        }
    }

    public void Lose()
    {
        message.text = "Поражение.";
        Time.timeScale = 0f;
        resultCanvas.gameObject.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
    

}
