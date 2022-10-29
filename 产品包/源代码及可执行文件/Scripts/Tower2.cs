using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 TilePos;
    public GameObject Tower2Picture;
    public GameObject tower2;
    public bool destroy;
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

        GameObject tmp = Instantiate(tower2, TilePos +new Vector3(0.8f, -0.3f, 0), Quaternion.identity);
        //
        //设置这个是格子的子物体
        tmp.GetComponent<Towerattack>().TilePos = tmp.transform.position;

        tmp.transform.parent = Tower2Picture.transform.parent;

        //消除这个位置的holder

        tmp.transform.parent.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        tmp.transform.parent.gameObject.GetComponent<TileScript>().status = 2;


        GameObject.Find("GameManager").GetComponent<GameManager>().money -= 70;
        Destroy(GameObject.Find("TowerPanel1(Clone)"));
        //透明？

        //然后生成实例化的塔？
    }
}
