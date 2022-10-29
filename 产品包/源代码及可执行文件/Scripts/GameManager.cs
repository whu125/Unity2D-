using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    //放塔的种类？
    public static int guankapanding;

    public GameObject towerPrefab;

    public int playerhp;

    public int money;


    //GameObject.Find("Canvas1/DefeatChoice/DefeatUI").SetActive(false);
    //GameObject.Find("Canvas1/DefeatBG").SetActive(false);
    void Start()
    {
        //GameObject.Find("Canvas1/DefeatChoice/DefeatUI").SetActive(false);
        // GameObject.Find("Canvas1/DefeatBG").SetActive(false);
        //  GameObject.Find("Canvas1/DefeatChoice").SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (playerhp == 0)
        {
            //跳转 游戏结束
            //  Debug.Log("游戏结束");
           
            SceneManager.LoadScene("Defeat");

        }


        if (GameObject.Find("MonsterPool").GetComponent<MosterPool>().waveIndex == GameObject.Find("MonsterPool").GetComponent<MosterPool>().waveCount
            && GameObject.Find("MonsterPool").GetComponent<MosterPool>().TotalMonsterList.Count == 0 && playerhp > 0)
        {
            // GameObject.Find("Canvas/root").GetComponent<DefeatMenu>().Victory_UIEnable();

            if(guankapanding == GameObject.Find("LevelManager").GetComponent<LevelManager>().guanka)
            guankapanding++;

            PlayerPrefs.SetInt("intKey", guankapanding);

            if (GameObject.Find("LevelManager").GetComponent<LevelManager>().guanka<6)
            SceneManager.LoadScene("Victory");

            else
            SceneManager.LoadScene("FinalWin");

        }

    }

    //当成工具类来使用？写一个工具函数



}
