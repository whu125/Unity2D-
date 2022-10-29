using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Moster : Singleton<Moster>
{
    public bool iffired;//是否烧伤
    private int burnCount;//烧伤次数
    public GameObject burn;
    public bool ifslow;//是否减速
    private float slowtime;//减速时长
    public GameObject lighting;

    public float HP;//血量
    public int times;//只加一次金币
    public Vector3 deltaVector2;
    public Vector3 deltaVector0;
    public Vector3 kouxiepanding;
    public int getmoney;//击杀后玩家获得的金币数量
    public float Max_HP;//怪物最大血量
    public bool IfDie = false;//状态
    public bool IfHurt = false;
    public Animator anim;
    //public static Moster mos = new Moster();
    public GameObject[] PointArray;//怪物移动坐标点集
    public int nowpoint;//当前所在的坐标点
    static public int point;
    public float speed;//速度
    public float Max_speed;
    public string DyingAnim;
    private int condition = 0;//让Die()只执行一次的参数
    public Slider bs;  //实例化一个Slider血条
    public bool road2;
    public bool road3;

    private Transform pos;

    //public void hurt(int hit)
    //{
    //    if (IfDie)
    //        return;
    //    IfHurt = true;
    //    HP -= hit;
    //}

    float Diex;
    float Diey;
    public void Die()
    {
        if (HP <= 0)
        {
            HP = 0;
            IfDie = true;
            Diex = this.transform.position.x;
            Diey = this.transform.position.y;//死亡时的位置，或许有用
            condition++;
        }
    }




    void Awake()
    {
        Max_speed = speed;
        pos = this.transform;
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        burnCount = 0;
        times = 1;
        HP = Max_HP;
        //  InvokeRepeating("hurtText", 0, 1);//死亡测试
        bs.value = 1;  //Value的值介于0-1之间，且为浮点数
        InvokeRepeating("FireHurt", 0, 1);
        InvokeRepeating("slowdown", 0, 1);
    }

    void FixedUpdate()
    {
        bs.value = HP / Max_HP;

        Move();

        if (burnCount >= 4)
        {
            CancelInvoke("FireHurt");
        }

        //slowdown();
        if (ifslow == true)
        {
            slowtime += Time.deltaTime;
            if (slowtime >= 1f)
            {
                speed += 0.01f;
                slowtime = 0;
                ifslow = false;
            }
        }

        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
        if (info.normalizedTime >= 1 && info.IsName(DyingAnim))
        {


            GameObject.Find("MonsterPool").GetComponent<MosterPool>().TotalMonsterList.Remove(gameObject);
            GameObject.Find("MonsterPool").GetComponent<MosterPool>().ReturnInstance(gameObject);

            if (GameObject.Find("tower11(Clone)")!=null)
            GameObject.Find("tower11(Clone)").GetComponent<Towerattack>().enemys.Remove(gameObject);
            if (GameObject.Find("tower12(Clone)") != null)
                GameObject.Find("tower12(Clone)").GetComponent<Towerattack>().enemys.Remove(gameObject);

            if (GameObject.Find("tower21(Clone)") != null)
                GameObject.Find("tower21(Clone)").GetComponent<Towerattack>().enemys.Remove(gameObject);

            if (GameObject.Find("tower22(Clone)") != null)
                GameObject.Find("tower22(Clone)").GetComponent<Towerattack>().enemys.Remove(gameObject);

            if (GameObject.Find("tower31(Clone)") != null)
                GameObject.Find("tower31(Clone)").GetComponent<Towerattack>().enemys.Remove(gameObject);

            if (GameObject.Find("tower32(Clone)") != null)
                GameObject.Find("tower32(Clone)").GetComponent<Towerattack>().enemys.Remove(gameObject);
            Debug.Log("...");
            //MosterPool.pool.ReturnInstance(gameObject);
            Destroy(gameObject);
        }//动画播放结束后销毁对象

        if (HP <= 0 && condition == 0)
        {
            anim.SetBool("IfDie", true);//动画变更参数设置
            CancelInvoke("hurtText");
            Die();

        }

        //死了加金币
        if (this.IfDie == true && times == 1)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().money += getmoney;
            times = 0;
        }

        if (this.IfDie == false)
        {
            this.transform.Translate(deltaVector2.x, deltaVector2.y, 0);//怪物移动
        }
        if (deltaVector0.magnitude < 0.1)
        {
            nowpoint++;
            point++;

        }

       

        if (road2 == true && nowpoint == 5 )
        {
            GameObject.Find("MonsterPool").GetComponent<MosterPool>().ReturnInstance(gameObject);
            //MosterPool.pool.ReturnInstance(gameObject);
            Destroy(gameObject);
            kouxiepanding = transform.position - GameObject.Find("Point8(Clone)").transform.position;
            if (kouxiepanding.magnitude < 0.1)
            {
                // Debug.Log("进了吗");
                GameObject.Find("GameManager").GetComponent<GameManager>().playerhp--;
                GameObject.Find("MonsterPool").GetComponent<MosterPool>().TotalMonsterList.Remove(gameObject);
                Destroy(gameObject);
            }



        }

        if (road2 == false && nowpoint == 5 && GameObject.Find("LevelManager").GetComponent<LevelManager>().guanka <= 5)
        {

            GameObject.Find("MonsterPool").GetComponent<MosterPool>().ReturnInstance(gameObject);
            //MosterPool.pool.ReturnInstance(gameObject);
            Destroy(gameObject);
            kouxiepanding = transform.position - GameObject.Find("Point6(Clone)").transform.position;
            if (kouxiepanding.magnitude < 0.1)
            {
                // Debug.Log("进了吗");
                GameObject.Find("GameManager").GetComponent<GameManager>().playerhp--;
                GameObject.Find("MonsterPool").GetComponent<MosterPool>().TotalMonsterList.Remove(gameObject);
                Destroy(gameObject);
            }
        }

        if (nowpoint == 7 && GameObject.Find("LevelManager").GetComponent<LevelManager>().guanka == 6)
        {
            GameObject.Find("MonsterPool").GetComponent<MosterPool>().ReturnInstance(gameObject);
            //MosterPool.pool.ReturnInstance(gameObject);
            Destroy(gameObject);
            if(this.gameObject.tag != "Boss")
            kouxiepanding = transform.position - GameObject.Find("Point8(Clone)").transform.position;
            else
            kouxiepanding = transform.position - GameObject.Find("Point16(Clone)").transform.position;
            if (kouxiepanding.magnitude < 0.1)
            {
                // Debug.Log("进了吗");
                GameObject.Find("GameManager").GetComponent<GameManager>().playerhp--;
                GameObject.Find("MonsterPool").GetComponent<MosterPool>().TotalMonsterList.Remove(gameObject);
                Destroy(gameObject);
            }
        }


    }


    public void Move()
    {
        if (road3 == true)
        {
            
            switch (nowpoint)
            {
               
                case 0:
                    deltaVector2 = speed * (GameObject.Find("Point2(Clone)").transform.position - GameObject.Find("Point1(Clone)").transform.position).normalized;
                    deltaVector0 = -transform.position + GameObject.Find("Point2(Clone)").transform.position;
                    Debug.Log("case 0");
                    break;

                case 1:
                    deltaVector2 = speed * (GameObject.Find("Point7(Clone)").transform.position - GameObject.Find("Point2(Clone)").transform.position).normalized;
                    deltaVector0 = -transform.position + GameObject.Find("Point7(Clone)").transform.position;
                    Debug.Log("case 1");
                    break;


                case 2:
                    deltaVector2 = speed * (GameObject.Find("Point8(Clone)").transform.position - GameObject.Find("Point7(Clone)").transform.position).normalized;
                    deltaVector0 = -transform.position + GameObject.Find("Point8(Clone)").transform.position;
                    break;
                case 3:
                    deltaVector2 = speed * (GameObject.Find("Point5(Clone)").transform.position - GameObject.Find("Point8(Clone)").transform.position).normalized;
                    deltaVector0 = -transform.position + GameObject.Find("Point5(Clone)").transform.position;
                    break;
                case 4:
                    deltaVector2 = speed * (GameObject.Find("Point6(Clone)").transform.position - GameObject.Find("Point5(Clone)").transform.position).normalized;
                    deltaVector0 = -transform.position + GameObject.Find("Point6(Clone)").transform.position;
                    break;
                default:
                    break;

            }
        }


        if (road2 == true)
        {
            switch (nowpoint)
            {
                case 0:
                    deltaVector2 = speed * (GameObject.Find("Point3(Clone)").transform.position - GameObject.Find("Point7(Clone)").transform.position).normalized;
                    deltaVector0 = -transform.position + GameObject.Find("Point3(Clone)").transform.position;
                    Debug.Log("case 0");
                    break;

                case 1:
                    deltaVector2 = speed * (GameObject.Find("Point2(Clone)").transform.position - GameObject.Find("Point3(Clone)").transform.position).normalized;
                    deltaVector0 = -transform.position + GameObject.Find("Point2(Clone)").transform.position;
                    Debug.Log("case 1");
                    break;


                case 2:
                    deltaVector2 = speed * (GameObject.Find("Point5(Clone)").transform.position - GameObject.Find("Point2(Clone)").transform.position).normalized;
                    deltaVector0 = -transform.position + GameObject.Find("Point5(Clone)").transform.position;
                    break;
                case 3:
                    deltaVector2 = speed * (GameObject.Find("Point4(Clone)").transform.position - GameObject.Find("Point5(Clone)").transform.position).normalized;
                    deltaVector0 = -transform.position + GameObject.Find("Point4(Clone)").transform.position;
                    break;
                case 4:
                    deltaVector2 = speed * (GameObject.Find("Point8(Clone)").transform.position - GameObject.Find("Point4(Clone)").transform.position).normalized;
                    deltaVector0 = -transform.position + GameObject.Find("Point8(Clone)").transform.position;
                    break;
                default:
                    break;

            }
        }

        if (road3==false && this.gameObject.tag != "Boss")
        {
            if (GameObject.Find("LevelManager").GetComponent<LevelManager>().guanka < 6 && road2 == false)
            {
                switch (nowpoint)
                {
                    case 0:
                        deltaVector2 = speed * (GameObject.Find("Point2(Clone)").transform.position - GameObject.Find("Point1(Clone)").transform.position).normalized;
                        deltaVector0 = -transform.position + GameObject.Find("Point2(Clone)").transform.position;
                        break;

                    case 1:
                        deltaVector2 = speed * (GameObject.Find("Point3(Clone)").transform.position - GameObject.Find("Point2(Clone)").transform.position).normalized;
                        deltaVector0 = -transform.position + GameObject.Find("Point3(Clone)").transform.position;
                        break;

                    case 2:
                        deltaVector2 = speed * (GameObject.Find("Point4(Clone)").transform.position - GameObject.Find("Point3(Clone)").transform.position).normalized;
                        deltaVector0 = -transform.position + GameObject.Find("Point4(Clone)").transform.position;
                        break;
                    case 3:
                        deltaVector2 = speed * (GameObject.Find("Point5(Clone)").transform.position - GameObject.Find("Point4(Clone)").transform.position).normalized;
                        deltaVector0 = -transform.position + GameObject.Find("Point5(Clone)").transform.position;
                        break;
                    case 4:
                        deltaVector2 = speed * (GameObject.Find("Point6(Clone)").transform.position - GameObject.Find("Point5(Clone)").transform.position).normalized;
                        deltaVector0 = -transform.position + GameObject.Find("Point6(Clone)").transform.position;
                        break;
                    default:
                        break;
                }
            }

            if (GameObject.Find("LevelManager").GetComponent<LevelManager>().guanka == 6)
            {
                switch (nowpoint)
                {
                    case 0:
                        deltaVector2 = speed * (GameObject.Find("Point2(Clone)").transform.position - GameObject.Find("Point1(Clone)").transform.position).normalized;
                        deltaVector0 = -transform.position + GameObject.Find("Point2(Clone)").transform.position;
                        break;

                    case 1:
                        deltaVector2 = speed * (GameObject.Find("Point3(Clone)").transform.position - GameObject.Find("Point2(Clone)").transform.position).normalized;
                        deltaVector0 = -transform.position + GameObject.Find("Point3(Clone)").transform.position;
                        break;

                    case 2:
                        deltaVector2 = speed * (GameObject.Find("Point4(Clone)").transform.position - GameObject.Find("Point3(Clone)").transform.position).normalized;
                        deltaVector0 = -transform.position + GameObject.Find("Point4(Clone)").transform.position;
                        break;
                    case 3:
                        deltaVector2 = speed * (GameObject.Find("Point5(Clone)").transform.position - GameObject.Find("Point4(Clone)").transform.position).normalized;
                        deltaVector0 = -transform.position + GameObject.Find("Point5(Clone)").transform.position;
                        break;
                    case 4:
                        deltaVector2 = speed * (GameObject.Find("Point6(Clone)").transform.position - GameObject.Find("Point5(Clone)").transform.position).normalized;
                        deltaVector0 = -transform.position + GameObject.Find("Point6(Clone)").transform.position;
                        break;
                    case 5:
                        deltaVector2 = speed * (GameObject.Find("Point7(Clone)").transform.position - GameObject.Find("Point6(Clone)").transform.position).normalized;
                        deltaVector0 = -transform.position + GameObject.Find("Point7(Clone)").transform.position;
                        break;
                    case 6:
                        deltaVector2 = speed * (GameObject.Find("Point8(Clone)").transform.position - GameObject.Find("Point7(Clone)").transform.position).normalized;
                        deltaVector0 = -transform.position + GameObject.Find("Point8(Clone)").transform.position;
                        break;
                    default:
                        break;
                }
            }

            //if (GameObject.Find("LevelManager").GetComponent<LevelManager>().guanka > 3 && GameObject.Find("LevelManager").GetComponent<LevelManager>().guanka < 6)
            //{
            //    switch (nowpoint)
            //    {
            //        case 0:
            //            deltaVector2 = speed * (GameObject.Find("Point2(Clone)").transform.position - GameObject.Find("Point1(Clone)").transform.position).normalized;
            //            deltaVector0 = -transform.position + GameObject.Find("Point2(Clone)").transform.position;
            //            break;

            //        case 1:
            //            deltaVector2 = speed * (GameObject.Find("Point3(Clone)").transform.position - GameObject.Find("Point2(Clone)").transform.position).normalized;
            //            deltaVector0 = -transform.position + GameObject.Find("Point3(Clone)").transform.position;
            //            break;

            //        case 2:
            //            deltaVector2 = speed * (GameObject.Find("Point4(Clone)").transform.position - GameObject.Find("Point3(Clone)").transform.position).normalized;
            //            deltaVector0 = -transform.position + GameObject.Find("Point4(Clone)").transform.position;
            //            break;
            //        case 3:
            //            deltaVector2 = speed * (GameObject.Find("Point5(Clone)").transform.position - GameObject.Find("Point4(Clone)").transform.position).normalized;
            //            deltaVector0 = -transform.position + GameObject.Find("Point5(Clone)").transform.position;
            //            break;
            //        case 4:
            //            deltaVector2 = speed * (GameObject.Find("Point6(Clone)").transform.position - GameObject.Find("Point5(Clone)").transform.position).normalized;
            //            deltaVector0 = -transform.position + GameObject.Find("Point6(Clone)").transform.position;
            //            break;
            //        case 5:
            //            deltaVector2 = speed * (GameObject.Find("Point7(Clone)").transform.position - GameObject.Find("Point6(Clone)").transform.position).normalized;
            //            deltaVector0 = -transform.position + GameObject.Find("Point7(Clone)").transform.position;
            //            break;
            //        case 6:
            //            deltaVector2 = speed * (GameObject.Find("Point8(Clone)").transform.position - GameObject.Find("Point7(Clone)").transform.position).normalized;
            //            deltaVector0 = -transform.position + GameObject.Find("Point8(Clone)").transform.position;
            //            break;
            //        default:
            //            break;
            //    }
            //}

            if (deltaVector0.x < 0)
            {
                Vector3 scale = this.transform.localScale;
                scale.x = -1;//镜像翻转 x,y,z都可以
                this.transform.localScale = scale;
            }
            else
            {
                Vector3 scale = this.transform.localScale;
                scale.x = 1;//镜像翻转 x,y,z都可以
                this.transform.localScale = scale;
            }
        }

        if (this.gameObject.tag == "Boss")
        {
            switch (nowpoint)
            {
                case 0:
                    deltaVector2 = speed * (GameObject.Find("Point10(Clone)").transform.position - GameObject.Find("Point9(Clone)").transform.position).normalized;
                    deltaVector0 = -transform.position + GameObject.Find("Point10(Clone)").transform.position;
                    break;

                case 1:
                    deltaVector2 = speed * (GameObject.Find("Point11(Clone)").transform.position - GameObject.Find("Point10(Clone)").transform.position).normalized;
                    deltaVector0 = -transform.position + GameObject.Find("Point11(Clone)").transform.position;
                    break;

                case 2:
                    deltaVector2 = speed * (GameObject.Find("Point12(Clone)").transform.position - GameObject.Find("Point11(Clone)").transform.position).normalized;
                    deltaVector0 = -transform.position + GameObject.Find("Point12(Clone)").transform.position;
                    break;
                case 3:
                    deltaVector2 = speed * (GameObject.Find("Point13(Clone)").transform.position - GameObject.Find("Point12(Clone)").transform.position).normalized;
                    deltaVector0 = -transform.position + GameObject.Find("Point13(Clone)").transform.position;
                    break;
                case 4:
                    deltaVector2 = speed * (GameObject.Find("Point14(Clone)").transform.position - GameObject.Find("Point13(Clone)").transform.position).normalized;
                    deltaVector0 = -transform.position + GameObject.Find("Point14(Clone)").transform.position;
                    break;
                case 5:
                    deltaVector2 = speed * (GameObject.Find("Point15(Clone)").transform.position - GameObject.Find("Point14(Clone)").transform.position).normalized;
                    deltaVector0 = -transform.position + GameObject.Find("Point15(Clone)").transform.position;
                    break;
                case 6:
                    deltaVector2 = speed * (GameObject.Find("Point16(Clone)").transform.position - GameObject.Find("Point15(Clone)").transform.position).normalized;
                    deltaVector0 = -transform.position + GameObject.Find("Point16(Clone)").transform.position;
                    break;
                default:
                    break;
            }

            if (deltaVector0.x < 0)
            {
                Vector3 scale = this.transform.localScale;
                scale.x = -1;//镜像翻转 x,y,z都可以
                this.transform.localScale = scale;
            }
            else
            {
                Vector3 scale = this.transform.localScale;
                scale.x = 1;//镜像翻转 x,y,z都可以
                this.transform.localScale = scale;
            }
        }
    }

    public void FireHurt()
    {
        if (iffired == true)
        {
            float temp = Max_HP;

            if (temp > 500)
            {
                temp = 500;
            }
            HP -= 0.1f * temp;
            burnCount++;

            Vector2 burnposition = this.transform.position;
            Instantiate(burn, burnposition, Quaternion.identity);
        }
    }
    public void slowdown()
    {
        if (ifslow == true)
        {
            float temp = Max_speed;
            speed = temp * 0.6f;

            Vector2 lightingposition = this.transform.position;
            Instantiate(lighting, lightingposition, Quaternion.identity);
        }
    }
}

