using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{

    public string BoomAnim;
    public Animator boomanim;
    void Update()
    {
        AnimatorStateInfo info = boomanim.GetCurrentAnimatorStateInfo(0);
        if (info.normalizedTime >= 1 && info.IsName(BoomAnim))
        {
            Destroy(this.gameObject);
        }//动画播放结束后销毁对象

    }
}
