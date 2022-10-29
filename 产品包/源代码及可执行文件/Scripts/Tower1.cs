using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower1 : MonoBehaviour
{
    public GameObject Tower1Picture;
    public GameObject tower1;
    public Vector3 TilePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        if (true)
        {
            PlaceTower();
        }
    }


    public void PlaceTower()
    {
        
        Destroy(GameObject.Find("Tower1(Clone)"));
        Destroy(GameObject.Find("Tower2(Clone)"));
        Destroy(GameObject.Find("Tower3(Clone)"));
        Destroy(GameObject.Find("Tower1Default(Clone)"));
        Destroy(GameObject.Find("Tower2Default(Clone)"));
        Destroy(GameObject.Find("Tower3Default(Clone)"));
        //GameObject tmp = Instantiate(tower1, new Vector3(transform.position.x + 0.15f, transform.position.y - 0.2f, 0), Quaternion.identity);
        GameObject tmp = Instantiate(tower1, TilePos, Quaternion.identity);
        //
        //设置这个是格子的子物体
        tmp.GetComponent<Towerattack>().TilePos = tmp.transform.position;
        
        tmp.transform.parent = Tower1Picture.transform.parent;

        //消除这个位置的holder

        tmp.transform.parent.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        tmp.transform.parent.gameObject.GetComponent<TileScript>().status = 2;


        //法二 销毁物体？这样子物体也会没有 父子关系颠倒？
        //先销毁再创建一个trans？

        GameObject.Find("GameManager").GetComponent<GameManager>().money -= 100;
        Destroy(GameObject.Find("TowerPanel1(Clone)"));
        //透明？

        //然后生成实例化的塔？
    }
}
