using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
#region 角色資料
{
    // 可讀性、維護性、擴充性
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
    [Header("檢查地面位移")]
   public Vector2 offset;
    [Header("檢查地面半徑")]
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
        rig.velocity = new Vector2(h * speed, rig.velocity.y);
        // 動畫 的 設定布林值(參數名稱，水平 不等於 0 時勾選)
        // "!=" 為不等於，返回布林值
        ani.SetBool("跑步開關", h != 0);

        // KeyCode 列舉(下拉式選單) - 所有輸入的項目 滑鼠-鍵盤-搖桿
        if (Input.GetKeyDown(KeyCode.D))
        {
            // transform 此物件的變形元件
            // eulerAngles 歐拉角度 0 --> 180 --> 360... 
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

    }

    /// <summary>
    /// 跳躍功能
    /// </summary>
    private void Jump()
    {
        //如果 角色在地面上 並且 按下空白鍵 才能跳躍 
        if (IsGround && Input.GetKeyDown(KeyCode.Space))
        {
            IsGround = false;                // 不在地面上了
            rig.AddForce(transform.up * jump);
        }
        else if (Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y) + offset, radius, 1 << 8))
        {
            IsGround = true;
        }
        else
        {
            IsGround = false;
        }
    }

    /// <summary>
    /// 開槍功能
    /// </summary>
    private void Fire()
    {
        //按下左鍵之後
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //音源 的 播放一次音效(音效，隨機大小聲)

            //生成子彈在槍口
            //生成(物件，座標，角度)
            GameObject temp = Instantiate(bullet, point.position, point.rotation);
            //讓子彈飛
            //上 綠 transform.up
            //右 紅 transform.right
            //前 藍 transform.forward
            temp.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletspeed + transform.up*150);
        }
        
    }

    /// <summary>
    /// 死亡功能
    /// </summary>
    /// <param name="obj">碰到物件的名稱</param>
    private void Dead(string obj)
    {
        //如果 物件名稱 等於 死亡區域
        //等於 == 
        if (obj == "死亡區域")
        {
            //this.enabled = false;
            enabled = false;                             // 此腳本 關閉
            ani.SetBool("死亡開關", true);

            //延遲呼叫("方法名稱",延遲時間)
            Invoke("Replay",2.5f);
        }
    }

    /// <summary>
    /// 重新遊戲
    /// </summary>
    private void Replay()
    {
        SceneManager.LoadScene("關卡");
    }


    // OCE 碰撞時執行一次的事件
    // collision 碰到物件的資訊
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Dead(collision.gameObject.name);
    }


    //繪製圖示:僅顯示於場景面板
    private void OnDrawGizmos()
    {
        // 圖示 顏色
        Gizmos.color = new Color(1, 0, 1, 0.4f);
        //圖示 繪製球體(中心點,半徑)
        Gizmos.DrawSphere(new Vector2(transform.position.x, transform.position.y) + offset, radius);
    }




    #endregion




}
