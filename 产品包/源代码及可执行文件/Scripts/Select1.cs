using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Select1 : MonoBehaviour
{
    // [SerializeField] public bool unlocked;

    public Image LockImage;
  //  public Image book;
    public GameObject SelectButton;
    public GameObject EnterChapter2;
    public GameObject BookButton;
    public void UpdataLLevelImage()
    {
        if (GameManager.guankapanding == 1)
        {
            // Debug.Log("进了吗");
            LockImage.gameObject.SetActive(true);
            SelectButton.SetActive(false);
            EnterChapter2.SetActive(false);
        }
        if (GameManager.guankapanding == 2)
        {
            // Debug.Log("第一关胜利进了吗");
            LockImage.gameObject.SetActive(false);
            SelectButton.SetActive(true);
            EnterChapter2.SetActive(false);
        }

        if (GameManager.guankapanding >= 3)
        {
            // Debug.Log("第一关胜利进了吗");
            LockImage.gameObject.SetActive(false);
            SelectButton.SetActive(true);
            EnterChapter2.SetActive(true);
            if(GameManager.guankapanding == 7)
            {
                BookButton.SetActive(true);
            }
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        GameManager.guankapanding= PlayerPrefs.GetInt("intKey");
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

    public void Enterbook()
    {
        SceneManager.LoadScene("Book");
    }

   
}
