using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class showmoney : MonoBehaviour
{
    // Start is called before the first frame update

    public Text moneyText;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = GameObject.Find("GameManager").GetComponent<GameManager>().money.ToString();
    }
}
