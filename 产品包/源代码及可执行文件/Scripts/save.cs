using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class save : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Save()
    {

    }

    public void Load()
    {
        int intVal = PlayerPrefs.GetInt("intKey");

        if (intVal >= 1 && intVal <= 7)
        {
            Debug.Log("当前存储的值是" + intVal);

            GameManager.guankapanding = intVal;

            switch (intVal)
            {
                //根据读取的值加载场景
                case 0: SceneManager.LoadScene(1); break;
                case 1: SceneManager.LoadScene(2); break;
                case 2: SceneManager.LoadScene(2); break;
                case 3: SceneManager.LoadScene(2); break;
                case 4: SceneManager.LoadScene(5); break;
                case 5: SceneManager.LoadScene(5); break;
                case 6: SceneManager.LoadScene(8); break;
                case 7: SceneManager.LoadScene(8); break;


            }
        }



    }

    public void newgame()
    {
       
        GameManager.guankapanding = 1;
        PlayerPrefs.SetInt("intKey", GameManager.guankapanding);
        Debug.Log("当前存储的值是" + PlayerPrefs.GetInt("intKey"));
        SceneManager.LoadScene(1);
    }

    public void firstnewgame()
    {
        int intVal = PlayerPrefs.GetInt("intKey");

        if (intVal< 1 || intVal > 7)
        {
            GameManager.guankapanding = 1;
            PlayerPrefs.SetInt("intKey", GameManager.guankapanding);
            Debug.Log("当前存储的值是" + PlayerPrefs.GetInt("intKey"));
            SceneManager.LoadScene(1);
        }
    }

    public void loadgroup()
    {

        
        SceneManager.LoadScene("Group");
    }
}
