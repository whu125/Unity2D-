using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lighting : MonoBehaviour
{
    public string SlowAnim;
    public Animator slowanim;
    public void slowing()
    {
        AnimatorStateInfo info = slowanim.GetCurrentAnimatorStateInfo(0);
        if (info.normalizedTime >= 1 && info.IsName(SlowAnim))
        {
            Destroy(this.gameObject);
        }//动画播放结束后销毁对象
    }

    // Update is called once per frame
    void Update()
    {
        slowing();
    }
}
