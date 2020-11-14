
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
  
    
    //分數
    private int score = 0;
    //音效來源
    private AudioSource aud;
    //2D鋼體
    private Rigidbody2D rig;
    //遊戲控制器
    private Animator anr;

#endregion




}
