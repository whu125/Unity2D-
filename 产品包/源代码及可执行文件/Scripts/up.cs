using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class up : MonoBehaviour
{
    public GameObject tower12;
    public GameObject tower22;
    public GameObject tower32;
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
            upTower();
        }
    }

    public void upTower()
    {
        Destroy(GameObject.Find("up(Clone)"));
        Destroy(GameObject.Find("updefault(Clone)"));
        //居然不会报错?
        if ( this.transform .parent.transform.Find("tower2(Clone)") !=null)
        {
            GameObject tmp = Instantiate(tower22, transform.position+new Vector3(-0.4f,-0.4f,0), Quaternion.identity);
          transform.parent.gameObject.GetComponent<TileScript>().status = 3;
            tmp.transform.parent = this.gameObject.transform.parent;
            //可以直接这样设置？
            //  this.gameObject.GetComponent<>()
            //非常蠢的办法
            //this.transform.parent.transform.Find("tower2(Clone)").position = new Vector3(88, 88, 0);
            Destroy(this.transform.parent.transform.Find("tower2(Clone)").gameObject);
        }
        //寻找子物体？
        if (this.transform.parent.transform.Find("tower11(Clone)") != null)
        {
            GameObject tmp = Instantiate(tower12, transform.position + new Vector3(0, -0.6f, 0), Quaternion.identity);
          transform.parent.gameObject.GetComponent<TileScript>().status = 3;
            tmp.transform.parent = this.gameObject.transform.parent;
            //可以直接这样设置？
            //  this.gameObject.GetComponent<>()
            //非常蠢的办法
            //this.transform.parent.transform.Find("tower2(Clone)").position = new Vector3(88, 88, 0);
            Destroy(this.transform.parent.transform.Find("tower11(Clone)").gameObject);
        }
        if (this.transform.parent.transform.Find("tower3(Clone)") != null)
        {
            GameObject tmp = Instantiate(tower32, transform.position + new Vector3(0, -0.6f, 0), Quaternion.identity);
         transform.parent.gameObject.GetComponent<TileScript>().status = 3;
            tmp.transform.parent = this.gameObject.transform.parent;
            //可以直接这样设置？
            //  this.gameObject.GetComponent<>()
            //非常蠢的办法
            //this.transform.parent.transform.Find("tower2(Clone)").position = new Vector3(88, 88, 0);
            Destroy(this.transform.parent.transform.Find("tower3(Clone)").gameObject);
        }

        GameObject.Find("GameManager").GetComponent<GameManager>().money -= 50;
        //  tmp.transform.parent = Tower1Picture.transform.parent;
    }
}
