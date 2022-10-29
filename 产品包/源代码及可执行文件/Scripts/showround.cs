using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class showround : MonoBehaviour
{
    // Start is called before the first frame update

    public Text wavesText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wavesText.text = GameObject.Find("MonsterPool").GetComponent<MosterPool>().waveIndex.ToString();
    }
}
