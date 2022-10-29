using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towerattack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletPrefeb;
    public List<GameObject> enemys = new List<GameObject>();
    public float cooltime;
    public float Timer;
    public Vector3 TilePos;
    public int num;
    public float radius;
    public int count;
    private bool IfContained = false;

    protected AudioSource SoundPlay;

    void Start()
    {
        SoundPlay = GetComponent<AudioSource>();
        SoundPlay.Play();
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemys.Count>0 && enemys[0] == null)
            enemys.Clear();

        //更新而不是
        num = GameObject.Find("MonsterPool").GetComponent<MosterPool>().TotalMonsterList.Count;
        //遍历 根据距离加入列表？ 怎么遍历敌人啊？


        for (int i = 0; i < num; i++)
        {
            if (GameObject.Find("MonsterPool").GetComponent<MosterPool>().TotalMonsterList[i] != null)
            {

                if ((this.transform.position - GameObject.Find("MonsterPool").GetComponent<MosterPool>().TotalMonsterList[i].transform.position).magnitude < radius)
                {
                    IfContained = false;
                    //Debug.Log("加了吗");
                    if (enemys.Contains(GameObject.Find("MonsterPool").GetComponent<MosterPool>().TotalMonsterList[i]))
                    {
                        IfContained = true;
                    }
                    //怎么只加一次啊？？？
                    if (IfContained == false && GameObject.Find("MonsterPool").GetComponent<MosterPool>().TotalMonsterList[i] != null)
                    {
                        enemys.Add(GameObject.Find("MonsterPool").GetComponent<MosterPool>().TotalMonsterList[i]);
                    }
                    //enemys.Add(GameObject.Find("MonsterPool").GetComponent<MosterPool>().TotalMonsterList[i]);

                }
                else
                {
                    enemys.Remove(GameObject.Find("MonsterPool").GetComponent<MosterPool>().TotalMonsterList[i]);
                }
            }

        }

        if (enemys.Count > 0)
            DieRemove();
       // Debug.Log(enemys.Count);
        if (Timer > cooltime && enemys.Count > 0)
        {
          
            Attack();
            Timer = 0;
            //    count = 0;
        }
        else
        {
            Timer += Time.deltaTime;
        }
        //   GameObject.Find("MonsterPool").GetComponent<MosterPool>().TotalMonsterList.Clear();
        //遍历怪物坐标
    }

    //public void OnTriggerStay(Collider2D collider)
    //
    //}
    void DieRemove()
    {
        for (int i = 0; i < enemys.Count; i++) {
            if (enemys[i] == null)
            {
                return;
            }
            else
            {
                if (enemys[i].GetComponent<Moster>().IfDie)
                {
                    enemys.Remove(enemys[i]);
                }
            }
        }
    }
    //public void OnTriggerEnter2D(Collider2D collider)
    //{
    //   // Debug.Log("烫烫烫");
    //    if (collider.tag == "Enemy")//检查标签
    //    {
    //        enemys.Add(collider.gameObject);

    //    }
    //}
    //public void OnTriggerExit2D(Collider2D collider)
    //{
    //    if (collider.tag == "Enemy")
    //        enemys.Remove(collider.gameObject);
    //}

    public void Attack()//攻击
    {
        if (enemys.Count > 0)//存在敌人
        {
            //  Debug.Log("生成了吗");
            GameObject bullet = Instantiate(bulletPrefeb, transform.position + new Vector3(0.2f, 0.2f, 0), Quaternion.identity);
            //bullet.GetComponent<Bullet>().SetTarget(enemys[0]);//子弹脚本中的方法
           // if (enemys[0]!= null)
            bullet.GetComponent<BulletArrow>().SetTarget(enemys[0]);//子弹脚本中的方法
        }

    }






}
