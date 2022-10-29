using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalWin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void returnmenu()
        {
        SceneManager.LoadScene(2);

    }

    public void returnstart()
    {
        SceneManager.LoadScene(0);
    }
}
