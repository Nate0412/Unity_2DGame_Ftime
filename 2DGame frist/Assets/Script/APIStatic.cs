
using UnityEngine;

public class APIStatic : MonoBehaviour
{
    private void Start()
    {
        //取得 靜態屬性
        //類別名稱.靜態屬性名稱
        //數學 的 拍
        print(Mathf.PI);
        //隨機 的 值
        //"字串"+ 其他類型 (串接)
        print("隨機;" + Random.value);

        //設定 靜態屬性
        //類別名稱.靜態屬性名稱 = 值;
        //時間 的 時間大小 = 值; 
        Time.timeScale = 10;

        //使用 靜態 方法
        int a = Mathf.Abs(-999);
        print("絕對值後的值:" + a);

        float atk = Random.Range(50.5f, 100.5f);
        print("隨機攻擊力" + atk);

        //練習 屬性
        print("攝影機總數:" + Camera.allCamerasCount);

        Cursor.visible = false;

        //練習 方法
        //Application.OpenURL("https://store.steampower.cpm//");

        float number = Mathf.Floor(1.234679f);
        print("去小數點:" + number);
    }

    private void Update()
    {
        print("是否按住任意鍵" + Input.anyKey);

        // print("遊戲時間" + Time.time);

        print("是否按下空白鍵" + Input.GetKeyDown("space"));
    }

}
