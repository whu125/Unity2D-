using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : Singleton<TileScript>
//这个从Singleton<TileScript>继承和从MonoBehaviour继承有什么不同
{
    Vector3 screenPosition;//将物体从世界坐标转换为屏幕坐标
    Vector3 mousePositionOnScreen;//获取到点击屏幕的屏幕坐标
    Vector3 mousePositionInWorld;//将点击屏幕的屏幕坐标转换为世界坐标

    public Point GridPosition { get; set; }

    public int tiletype;

    public int status; //0表示空 1表示一级塔 2表示二级塔
    public GameObject tmp;
    public GameObject tmp2;
    public GameObject tmp3;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

    }
    //void LateUpdate()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //        Debug.Log(mousePositionInWorld);
    //    }
    //}
    public void Setup(Point gridPos/*,Vector3 worldPos*/)
    {
        this.GridPosition = gridPos;
        //transform.position = worldPos;


    }
    /// <summary>
    /// 点击屏幕坐标
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>

    public void OnMouseDown()

    //OnMouseDown 自带
    {
        Destroy(GameObject.Find("up(Clone)"));
        Destroy(GameObject.Find("updefault(Clone)"));
        Destroy(GameObject.Find("Tower1(Clone)"));
        Destroy(GameObject.Find("Tower2(Clone)"));
        Destroy(GameObject.Find("Tower3(Clone)"));
        Destroy(GameObject.Find("Tower1Default(Clone)"));
        Destroy(GameObject.Find("Tower2Default(Clone)"));
        Destroy(GameObject.Find("Tower3Default(Clone)"));
        // Debug.Log("点了吗");

        int money = GameObject.Find("GameManager").GetComponent<GameManager>().money;

        if (status == 0 && tiletype != 0)//后期改
        {
            //待改进
            //  status = 1;
            //  if(status)


            if (money >= 100)
            {
                tmp = Instantiate(TowerPanel.Instance.smallPrefab1, new Vector3(transform.position.x + 0.15f, transform.position.y - 0.2f, 0), Quaternion.identity);
                tmp.GetComponent<Tower1>().TilePos = transform.position;
                tmp.GetComponent<Tower1>().Tower1Picture = tmp;
                tmp.transform.parent = this.gameObject.transform;
            }
            else
            {
                tmp = Instantiate(TowerPanel.Instance.smalldefaultPrefab1, new Vector3(transform.position.x + 0.15f, transform.position.y - 0.2f, 0), Quaternion.identity);
               
            }


            if (money >= 70)
            {
                tmp2 = Instantiate(TowerPanel.Instance.smallPrefab2, new Vector3(transform.position.x + 0.85f, transform.position.y - 0.2f, 0), Quaternion.identity);
                tmp2.GetComponent<Tower2>().TilePos = transform.position;
                tmp2.GetComponent<Tower2>().Tower2Picture = tmp2;
                tmp2.transform.parent = this.gameObject.transform;

            }
            else
            {
                tmp2 = Instantiate(TowerPanel.Instance.smalldefaultPrefab2, new Vector3(transform.position.x + 0.85f, transform.position.y - 0.2f, 0), Quaternion.identity);
            }

            if (money >= 150)
            {
                tmp3 = Instantiate(TowerPanel.Instance.smallPrefab3, new Vector3(transform.position.x + 1.55f, transform.position.y - 0.2f, 0), Quaternion.identity);
                tmp3.GetComponent<Tower3>().TilePos = transform.position;
                tmp3.GetComponent<Tower3>().Tower3Picture = tmp3;
                tmp3.transform.parent = this.gameObject.transform;

            }

            else
            {
                tmp3 = Instantiate(TowerPanel.Instance.smalldefaultPrefab3, new Vector3(transform.position.x + 1.55f, transform.position.y - 0.2f, 0), Quaternion.identity);
            }

            //代码挂载相当于组件 getcomponent通过组件设置另一个组件
            //=号可以直接赋值吧？
         

            //tmp.transform.parent = this.gameObject.transform;
            //tmp2.transform.parent = this.gameObject.transform;
            //tmp3.transform.parent = this.gameObject.transform;

        }

        if (status == 2)
        {

            if(money>=50)
            {
                GameObject tmp = Instantiate(TowerPanel.Instance.upPrefab, new Vector3(transform.position.x + 0.85f, transform.position.y + 0.6f, 0), Quaternion.identity);
                tmp.transform.parent = this.gameObject.transform;
              
            }
            else
            {
                GameObject tmp2 = Instantiate(TowerPanel.Instance.updefaultPrefab, new Vector3(transform.position.x + 0.85f, transform.position.y + 0.6f, 0), Quaternion.identity);
                tmp2.transform.parent = this.gameObject.transform;

            }
           
            //   tmp.GetComponent<Tower1>().Tower1Picture = tmp;
            //这里升级得用其他面板

            //需要设置为塔的子物体
           

        }
        //塔的集成设计？
    }


}
