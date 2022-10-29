using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager_Select : MonoBehaviour
{
    [SerializeField] public bool unlocked;
    public Image LockImage;
    public GameObject SelectButton;
    public void UpdataLLevelImage()
    {
        if (!unlocked)
        {
            LockImage.gameObject.SetActive(true);
            SelectButton.SetActive(false);
        }
        else
        {
            LockImage.gameObject.SetActive(false);
            SelectButton.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdataLLevelImage();
    }
    public void EnterNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //当成工具类来使用？写一个工具函数
    public void EnterChapter1_2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

    }
    public void EnterNextChapter()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);

    }
    public void FallBackChapter()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
}
