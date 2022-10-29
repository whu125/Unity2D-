using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCreate : MonoBehaviour
{
    public Vector3 TilePos;
   // public GameObject TowerPicture;
 //   Start is called before the first frame update
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
            Debug.Log("点了吗");
        }
    }


    public void PlaceTower()
    {
        GameObject tmp = Instantiate(GameManager.Instance.towerPrefab, TilePos, Quaternion.identity);
        //
        //设置这个是格子的子物体
        //tmp.GetComponent<Towerattack>().TilePos = tmp.transform.position;
        //tmp.transform.parent = TowerPicture.transform.parent;

        //消除这个位置的holder
        //法一 透明度？
        //法三：sprite置为null
        //  tmp.transform.parent.gameObject.GetComponent<SpriteRenderer>().sprite=null ;
        tmp.transform.parent.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        tmp.transform.parent.gameObject.GetComponent<TileScript>().status = 2;

        //法二 销毁物体？这样子物体也会没有 父子关系颠倒？
        //先销毁再创建一个trans？

        Destroy(GameObject.Find("TowerPanel1(Clone)"));
        //透明？

        //然后生成实例化的塔？
    }
}
