using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public int guanka;
    public GameObject[] tilePrefabs;//何处添加元素？
    public Vector3 TopLeftCorner;
    public string[] mapData;
    public Vector3 BottomRightCorner;
    public float Unit;
    //  public float height;
    public Vector3 worldStart;
    //public string[] mapData; 
    public float TileSize
    {
        //    get { return tilePrefabs[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x; }

        get
        {
            float width = -TopLeftCorner.x + BottomRightCorner.x;
            return width / Unit;
        }

    }
    //属性和字段？
    public Vector2 WorldToGrid(Vector3 WorldPos)
    {
        Vector2 GridPos = new Vector2(0, 0);
        GridPos.x = (WorldPos.x - worldStart.x) / TileSize;
        GridPos.y = (WorldPos.y - worldStart.y) / TileSize;

        return GridPos;
    }
    public Vector3 GridToWorld(Vector2 GridPos)
    {
        Vector3 WorldPos = new Vector3(0, 0, 0);
        WorldPos.x = -TileSize / 2 + GridPos.x * TileSize + worldStart.x;
        WorldPos.y = 10.0f / 14 - GridPos.y * TileSize + worldStart.y;

        //TileSize还有问题！！点暂时没有对应

        //  Debug.Log(WorldPos.x);
        return WorldPos;
    }
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log(TileSize);
        TopLeftCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));
        BottomRightCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1));
        Unit = 14f;
        worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));  //以左下角为起点 该点为左上角
        //mapData = new string[] {
        //    "222222222222",
        //    "222222222222",
        //    "000012121212",
        //    "111000001212",
        //    "222212100000",
        //    "222222222222",
        //    "222222222222",

        //};
        CreateLevel();
        Debug.Log(worldStart);

    }
    // Update is called once per frame
    void Update()
    {
        //debug.log(input.mouseposition.x);
        //debug.log(input.mouseposition.y);
        //Debug.Log(worldStart.x);
        //Debug.Log(TileSize);

    }

    public void CreateLevel()
    {


        if (guanka == 1)
        {
            mapData = new string[]
            {
            "22222222222222",
            "22222222222222",
            "00001212121212",
            "11100000121212",
            "22221210000000",
            "22222222222222",
            "22222222222222",
             };
        }

        if (guanka == 2)
        {

            mapData = new string[]
            {
            "22222222222222",
            "00002222000000",
            "21201221012212",
            "22102222022222",
            "22201212012222",
            "22200000022222",
            "22221212222222",




            };
        }

        if (guanka == 3)
        {

            mapData = new string[]
            {
            "20222222222222",
            "20222222222222",
            "20122000000022",
            "20121011111022",
            "20111012221022",
            "20000022222022",
            "22222222222022",
            "22222222222022",




            };
        }

        if (guanka == 4)
        {

            mapData = new string[]
            {
            "22222222222222",
            "22222222222222",
            "00000000000000",
            "01101111011112",
            "01101111011112",
            "00000000000000",
            "22222222222222",




            };
        }
        if (guanka == 5)
        {

            mapData = new string[]
            {
            "22222222222222",
            "22220000022222",
            "22210111012222",
            "00000121000000",
            "22110121011222",
            "22220111022222",
            "22220000022222",
            "22222222222222",



            };
        }
        if (guanka == 6)
        {

            mapData = new string[]
            {
            "22222222222222",
            "00000000000000",
            "22221212121210",
            "00000000000000",
            "01212121212122",
            "00000000000000",
            "22221212121210",
            "00000000000000",



            };
        }

        //这个是根据已知数组得到的 不好
        int mapX = mapData[0].ToCharArray().Length;
        int mapY = mapData.Length;
        //横向放十五个大小  其他绘制方法？读取文件？

        //地图大小：12×7 

        for (int y = 0; y < mapY; y++)
        {
            char[] newTiles = mapData[y].ToCharArray();
            for (int x = 0; x < mapX; x++)
            {
                PlaceTile(newTiles[x].ToString(), x, y, worldStart);
            }
        }
    }

    public void PlaceTile(string tileType, int x, int y, Vector3 worldStart)
    {
        int tileIndex = int.Parse(tileType);

        GameObject newTile = Instantiate(tilePrefabs[tileIndex]);
        //Instantiate(Object original)：
        //克隆物体original，其Position和Rotation取默认值，默认值是预制体的position，这里的position是世界坐标，无父物体



        //
        //   float OriginScale = tilePrefabs[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        //   newTile.transform.localScale = new Vector3(TileSize/OriginScale,TileSize/OriginScale, 1);
        //这个制作方法不太行？

        newTile.transform.position = new Vector3(worldStart.x + (TileSize * x), worldStart.y - (TileSize * y), 0);
        //不能单独对x y赋值
        newTile.GetComponent<TileScript>().tiletype = tileIndex;
        newTile.GetComponent<TileScript>().status = 0;
        newTile.GetComponent<TileScript>().Setup(new Point(x, y));

    }


}

