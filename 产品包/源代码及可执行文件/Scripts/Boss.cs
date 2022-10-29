using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public void speedUp()
    {
        if (this.gameObject.GetComponent<Moster>().bs.value < 0.5f)
        {
            this.gameObject.GetComponent<Moster>().speed = 0.035f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        speedUp();
    }
}