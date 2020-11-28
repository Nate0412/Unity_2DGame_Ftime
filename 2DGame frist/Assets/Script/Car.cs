using System;
using UnityEngine;

public class Car : MonoBehaviour
{
    #region 練習欄位
    // 單行註解:紀錄、筆記、說明、開發者名稱...
    // 資料 = C# 欄位(Field)
    // 語法:
    // 修飾詞 類型 名稱 (指定 值):
    // 修飾詞-定義資料的權限
    // 私人 private(預設值)- 不顯示在屬性面板
    // 公開 public - 顯示在屬性面板
    // 四大基本類型:整數(int)、浮點數(float)、字串(String)、布林值(bool)

    [Header("CC")]                    //Header為標題Tooltip為提示內容;可由,連接
    [Tooltip("汽車的CC數"), Range(1000, 2000)]
    public int cc = 2000;
    [Header("重量"), Tooltip("汽車重量"), Range(500, 2500)]
    public float weight = 1500.5f;  //小數點後面的數字要加 f 或是 F
    public string brand = "KKK";    //字串要使用""框起來
    public bool HaveWindow = true;  //只有 是(True)、否(Fales)

    //其他類型 顏色、座標 2~4、元件(屬性面板上的粗體字Rigidbody2、collider2D)
    public Color red = Color.red;
    public Color yellow = Color.yellow;
    public Color mycolor = new Color(5f, 0, 3f);

    //2~4維向量
    public Vector2 pos0 = Vector2.zero;
    public Vector2 pos1 = Vector2.one;
    public Vector2 pos2 = new Vector2(8, 6);

    //遊戲物件和元件不需要 指定 值

    public GameObject obj;      //可存放白線物件和預製物
    public RectTransform tra;
    public SpriteRenderer spr;

    #endregion

    //事件:
    private void Start()
    {
        print("哈囉!沃德~");

        shoot(1, 400);
        shoot(2, 800);
        shoot(3, 600);
        shoot(4);

    }
    private void Update()
    { print("我泡在事件裡~");
 
        drive(0.1f);

        
    }
   

    private void drive(float drive)
    { print("開車中");
        transform.Translate(drive, 0, 0);
    }

    /// <summary>
    /// 調整子彈數量及開槍速度
    /// </summary>
    /// <param name="count">調整子彈數量</param>
    /// <param name="shoot">調整開槍速度,預設值=300</param>
    private void shoot(int count,int shoot=300)
    {
        print("子彈數量:"+ count);
        print("開槍速度:" + shoot);
    }









}


   
    


