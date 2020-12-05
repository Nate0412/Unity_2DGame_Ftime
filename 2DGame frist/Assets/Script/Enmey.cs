using UnityEngine;

public class Enmey : MonoBehaviour
{
    #region 欄位


    [Header("移動速度"), Range(0, 1000)]
    public float speed = 10.5f;
    [Header("跳躍高度"), Range(0, 3000)]
    public int jump = 100;
    [Header("是否在地板上"), Tooltip("打勾為在地上取消則否")]
    public bool IsGround = false;
    [Header("子彈"), Tooltip("子彈種類")]
    public GameObject bullet;
    [Header("子彈生成點"), Tooltip("子彈位置")]
    public Transform point;
    [Header("子彈速度"), Range(0, 5000)]
    public int bulletspeed = 800;
    [Header("開槍音效"), Tooltip("槍聲")]
    public AudioClip fireSound;
    [Header("追蹤範圍"), Range(0, 1000)]
    public float rangeTrack = 10.5f;
    [Header("攻擊範圍"), Range(0, 1000)]
    public float rangeAttack =9.5f;



    #endregion

    public Transform player;
    private Rigidbody2D rig;

    #region 方法

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        //面向玩家;當玩家的 x 大於 敵人的 x 角度等於0，否則角度等於 180
        if (player.position.x > transform.position.x)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        float dis = Vector3.Distance(transform.position, player.position);

        if (dis < rangeAttack)
        {
            Fire();
        }
        else if(dis < rangeTrack)
        {
            rig.velocity = transform.right * speed;
            rig.velocity = new Vector2(rig.velocity.x, rig.velocity.y);
        }
        
    }

    /// <summary>
    /// 開槍
    /// </summary>
    private void Fire()
    {
        rig.velocity = Vector3.zero;
    }

    private Animator ani;
    /// <summary>
    /// 死亡
    /// </summary>
    private void Dead()
    {
        enabled = false;
        ani.SetBool("死亡開關", true);
        GetComponent<CapsuleCollider2D>().enabled = false;   // 關閉碰撞器
        rig.Sleep();                                         // 剛體睡著

        //Destroy(GameObject, 3f)  刪除(遊戲物件,延遲秒數)
    }

    #endregion

    #region 事件

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 1, 0, 0.6f);
        Gizmos.DrawSphere(transform.position, rangeTrack);
        Gizmos.color = new Color(1, 0, 1, 0.3f);
        Gizmos.DrawSphere(transform.position, rangeAttack);
    }

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();

        //玩家變形 = 遊戲物件.尋找("玩家物件名稱").變形
        player = GameObject.Find("玩家").transform;
        
    }
    private void Update()
    {
        Move();
    }
    #endregion

}
