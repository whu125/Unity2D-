using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    public Text goldText;
    public Text wavesText;
    public Text heartText;
    public AudioMixer audioMixer;

    public void Update()
    {
        ChangeMoney();
        ShowWaves();
        ShowheartNum();
    }
    void ChangeMoney()
    {
        goldText.text = GameObject.Find("GameManager").GetComponent<GameManager>().money.ToString();
    }
    void ShowWaves()
    {
        wavesText.text = GameObject.Find("MonsterPool").GetComponent<MosterPool>().waveIndex.ToString();
    }
    void ShowheartNum()
    {
        heartText.text = GameObject.Find("GameManager").GetComponent<GameManager>().playerhp.ToString();
    }
    public GameObject pauseMenu;
    public void Start()
    {
        
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);

    }
    public void ReturnGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void SetVolume(float value)
    {
        audioMixer.SetFloat("GameVolume", value);
    }

   

}
