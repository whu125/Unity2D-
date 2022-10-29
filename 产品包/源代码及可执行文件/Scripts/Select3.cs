using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Select3 : MonoBehaviour
{
    // [SerializeField] public bool unlocked;

    public Image LockImage;
    public GameObject SelectButton;
    //public GameObject EnterChapter;
    public GameObject BackChapter;
    public void UpdataLLevelImage()
    {
        if (GameManager.guankapanding == 5)
        {
            // Debug.Log("进了吗");
            LockImage.gameObject.SetActive(true);
            SelectButton.SetActive(false);
            BackChapter.SetActive(true);
          //  EnterChapter.SetActive(false);
        }
        if (GameManager.guankapanding == 6)
        {
            // Debug.Log("第一关胜利进了吗");
            LockImage.gameObject.SetActive(false);
            BackChapter.SetActive(true);
            SelectButton.SetActive(true);
           // EnterChapter.SetActive(false);

        }

        if (GameManager.guankapanding == 7)
        {
            // Debug.Log("第一关胜利进了吗");
            LockImage.gameObject.SetActive(false);
            BackChapter.SetActive(true);
            SelectButton.SetActive(true);
           // EnterChapter.SetActive(true);

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GameManager.guankapanding = PlayerPrefs.GetInt("intKey");
        Debug.Log(GameManager.guankapanding);
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

