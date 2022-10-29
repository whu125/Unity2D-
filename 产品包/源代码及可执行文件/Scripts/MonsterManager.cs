using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : Singleton<MonsterManager>
{

    // Start is called before the first frame update
    public int MonsterNum01 = 3;//01怪物总数
    public int m_Num = 0;//已经出来的怪物数量
    public GameObject monsterPrefab;
    public GameObject MonsterPrefab
    {
        get
        { return monsterPrefab; }
    }
    void Start()
    {
        InvokeRepeating("showmonster", 0, 2);
   // showmonster();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Num >= MonsterNum01) {
            CancelInvoke("showmonster");
            m_Num = 0;
        }
    }

    void showmonster()
    {
        Instantiate(monsterPrefab, transform.position, Quaternion.identity);
        m_Num++;
    }
}
