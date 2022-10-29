using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class showheart : MonoBehaviour
{
    // Start is called before the first frame update

    public Text heartText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       heartText.text = GameObject.Find("GameManager").GetComponent<GameManager>().playerhp.ToString();
    }
}
