
using UnityEngine;

public class Player : MonoBehaviour
#region 角色資料
{
    [Header("移動速度"), Range(0, 1000)]
    public float speed = 10.5f;
    [Header("跳躍高度"), Range(0, 3000)]
    public int jump = 100;
    [Header("是否在地板上"),Tooltip("打勾為在地上取消則否")]
    public bool IsGround = false;
    [Header("子彈"), Tooltip("子彈種類")]
    public GameObject bullet;
    [Header("子彈生成點"),Tooltip("子彈位置")]
    public Transform point;
    [Header("子彈速度"),Range(0,5000)]
    public int bulletspeed = 800;
    [Header("開槍音效"),Tooltip("槍聲")]
    public AudioClip fireSound;    
    [Header("生命數量"), Range(0,10)]
    public int life = 3;
   [Header("檢查地面位移"),]
   public Vector2 offset;
    [Header("檢查地面半徑"),]
    public float radius = 0.3f;

    //分數
    private int score;
    //音效來源
    private AudioSource aud;
    //2D鋼體
    private Rigidbody2D rig;
    //遊戲控制器
    private Animator ani;

    // 事件:喚醒 - 在 Start 之前執行一次
    private void Awake()
    {
        // 鋼體 - 取得元件<鋼體元件>();
        // 抓到角色身上的鋼體元件存放到rig欄位內
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();

    }
    private void Update()
    {
        Move();
        Fire();
        Jump();
    }

    /// <summary>
    /// 移動功能
    /// </summary>
    private void Move()
    {
        // 水平浮點數 = 輸入的取得軸向("水平") - 左右AD
        float h = Input.GetAxis("Horizontal");
        // 鋼體的加速度 = 新 二維的向量(水平浮點數 * 速度，鋼體的假速度的Ｙ)
        rig.velocity = new Vector2(h = speed, rig.velocity.y);
        //
        //
        ani.SetBool("跑步開關", h != 0);
    }

    /// <summary>
    /// 跳躍功能
    /// </summary>
    private void Jump()
    {

    }

    /// <summary>
    /// 開槍功能
    /// </summary>
    private void Fire()
    {

    }

    /// <summary>
    /// 死亡功能
    /// </summary>
    /// <param name="obj">碰到物件的名稱</param>
    private void Dead(string obj)
    {

    }







    #endregion




}
