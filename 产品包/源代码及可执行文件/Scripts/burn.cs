using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burn : MonoBehaviour
{
    public string BurnAnim;
    public Animator burnanim;
    public void burning()
    {
        AnimatorStateInfo info = burnanim.GetCurrentAnimatorStateInfo(0);
        if (info.normalizedTime >= 1 && info.IsName(BurnAnim))
        {
            Destroy(this.gameObject);
        }//动画播放结束后销毁对象
    }
    // Update is called once per frame
    void Update()
    {
        burning();
    }
}
