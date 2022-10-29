using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosterPool : Singleton<MosterPool>
{
    //public static MosterPool pool = new MosterPool();

    //空池触发
    //public GameObject _prefab;//要加载和实例化的资源对象

    //对象池存储的实质，利用队列思想来存取物体
    public Queue<GameObject> _pooledInstanceQueue = new Queue<GameObject>();
    public List<GameObject> mList = new List<GameObject>();
    public List<GameObject> TotalMonsterList = new List<GameObject>();
    public GameObject[] PointArray;

    public List<GameObject> mosterType = new List<GameObject>();

    // 波次结构体
    public struct Wave
    {
        //波次间隔
        public float waveInterval;
        //怪物间隔
        public float monsterInterval;
        //怪物个数
        public int monsterCount;
    }
    //波次
    public int waveCount;
    //波次数组
    public Wave[] waves;
    //可以初始化
    private bool canInit = true;
    //计数器、计时器

    private float waveTimer = 0;

    private float monsterTimer = 0;

    public int waveIndex = 0;//波数计数器

    private int monsterIndex = 0;//怪物数量计数器

    //GetInstance:得到对象函数，内部判断当前队列数量是否为0（是否空池），如果空池则创建资源，否则从池子中取得对象返回。
    //取的对象后，对象池不会在对该对象处理，因此是移除了队列。
    public GameObject GetInstance()
    {
        //if (_pooledInstanceQueue.Count > 0)//有则取用
        //{
        //    GameObject instanceToReuse = _pooledInstanceQueue.Dequeue();
        //    instanceToReuse.SetActive(true);
        //    return instanceToReuse;
        //}
        if (GameObject.Find("LevelManager").GetComponent<LevelManager>().guanka == 4
            && waveIndex >= waveCount / 2)
        {
            return Instantiate(mosterType[waveIndex], GameObject.Find("Point7(Clone)").transform.position, Quaternion.identity);//无则创建
        }

        else

        {
            return Instantiate(mosterType[waveIndex], GameObject.Find("Point1(Clone)").transform.position, Quaternion.identity);//无则创建
        }

        //return Instantiate(_prefab, transform.position, Quaternion.identity);//无则创建
    }


    //ReturnInstance():返回对象函数，对象池有进有出，当外部功能用完资源后，通过该函数重新让资源入池。
    //这里处理了让对象重新进入队列，同时关闭物体激活和设置父物体。
    /*当一个游戏物体拖到另一个游戏物体的下面，这两个物体就组成了父子物体
     * 特点：1.父物体发生Transform变化的时候，子物体跟随一起变化，但是子物体发生变化的时候，父物体不动
             2.一个父物体可以有多个子物体，但是一个子物体只能有一个父物体，满足树状结构，最上层的叫做根物体*/
    public void ReturnInstance(GameObject gameObjectToPool)
    {
        _pooledInstanceQueue.Enqueue(gameObjectToPool);
        //gameObjectToPool.SetActive(false);
        // gameObjectToPool.transform.SetParent(gameObject.transform);
    }

    public void OnEnable1()
    {
        var obj = this.GetInstance();
        mList.Add(obj);
        TotalMonsterList.Add(obj);
    }

    public void OnDisable()
    {
        for (int i = 0; i < mList.Count; i++)
        {
            this.ReturnInstance(mList[i]);
        }
    }

    void Awake()
    {
        // 初始化数组
        waves = new Wave[waveCount];
    }

    void Start()
    {
        //设置第一波怪的信息
        waves[0].waveInterval = 1f;

        waves[0].monsterInterval = 1.5f;

        waves[0].monsterCount = 2;

        if (waves.Length != 11)
            for (int i = 1; i < waves.Length; i++)
            {
                waves[i].waveInterval = 7;//waves[0].waveInterval - i * 0.1f;

                waves[i].monsterInterval = waves[0].monsterInterval - i * 0.1f;

                waves[i].monsterCount = waves[0].monsterCount + i;

                if (waves[i].monsterCount > 6) waves[i].monsterCount = 6;

            }//往后怪物强度逐波增强（暂用）

        if (waves.Length == 12)
        {
            for (int i = 1; i < waves.Length; i++)
            {
                waves[i].waveInterval = 7;//waves[0].waveInterval - i * 0.1f;

                waves[i].monsterInterval = 1.5f;

            }//往后怪物强度逐波增强（暂用）

            waves[0].monsterCount = 5;
            waves[1].monsterCount = 6;
            waves[2].monsterCount = 5;
            waves[3].monsterCount = 6;
            waves[4].monsterCount = 7;
            waves[5].monsterCount = 7;
            waves[6].monsterCount = 7;
            waves[7].monsterCount = 7;
            waves[8].monsterCount = 5;
            waves[9].monsterCount = 8;
            waves[10].monsterCount = 7;
            waves[11].monsterCount = 1;


        }//最后一波

        for (int i = 0; i < PointArray.Length; i++)
        {
            GameObject tmp = Instantiate(PointArray[i]);
        }
    }

    void Update()
    {

        if (!canInit)
        {
            return;
        }

        waveTimer += Time.deltaTime;//时间流逝

        if (waveTimer >= waves[waveIndex].waveInterval)//时间到了，生成一波怪
        {
            //如果当期波次的怪物没有生成完毕
            if (monsterIndex < waves[waveIndex].monsterCount)
            {
                //怪物计时器计时
                monsterTimer += Time.deltaTime;//时间流逝

                if (monsterTimer >= waves[waveIndex].monsterInterval)//时间到了，生成一只怪
                {
                    OnEnable1();//产怪
                    //怪物计数器++
                    monsterIndex++;
                    //怪物计时器归零
                    monsterTimer = 0;
                }
            }
            else
            {
                //波次++
                waveIndex++;
                //怪物计数器归零
                monsterIndex = 0;
                //波次计时器归零
                waveTimer = 0;
                //怪物计时器归零
                monsterTimer = 0;

                mList.Clear();
            }

        }
        if (waveIndex >= waveCount)//达到总波数
        {
            canInit = false;
        }

        //for (int i = 0; i < TotalMonsterList.Count; i++)
        //{
        //    if (/*TotalMonsterList[i]==null || */TotalMonsterList[i].GetComponent<Moster>().HP<=0)
        //    {
        //        TotalMonsterList.Remove(TotalMonsterList[i]);
        //    }
        //}//统计当前地图上的怪物数量TotalMoster

        //if (mList.Count >= MaxNum01 && order == 0)
        //{
        //    CancelInvoke("OnEnable1");
        //    type++;
        //    order++;
        //    mList.Clear();
        //}
        //if (mList.Count >= MaxNum02 && order == 1)
        //{
        //    CancelInvoke("OnEnable2");
        //    type++;
        //    order++;
        //    mList.Clear();
        //}
    }
}



