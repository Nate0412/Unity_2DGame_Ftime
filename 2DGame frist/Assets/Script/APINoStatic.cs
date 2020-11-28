using UnityEngine;

public class APINoStatic : MonoBehaviour
{
    public GameObject objA;
    public GameObject objB;

    public Transform traA;
    public Transform traB;

    private void Start()
    {
        // 取得 非靜態 屬性
        // 遊戲物件 A 的 標籤
        print(objA.tag);
        print(objB.layer);
        print(traA.localScale);


        // 設定 非靜態 屬性
        objA.layer = 5;
        traA.localScale = new Vector3(3, 3, 3);

    }
    public void Update()
    {
        // 使用 非靜態 方法
        // 物件的方法(參數)
        // 變形物件 的 旋轉(X,Y,Z)
        traB.Rotate(0,0,100);
    }

}
