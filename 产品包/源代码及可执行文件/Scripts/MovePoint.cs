using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoint : MonoBehaviour
{
    
    public Vector2 GridPosition;

    //自定义类好像不是这样用的
   

    void Start()
    {

        this.transform.position = LevelManager.Instance.GridToWorld(GridPosition);


       // DontDestroyOnLoad(LevelManager.Instance);


    }
}
