using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("目標")]
    public Transform target;
    [Header("追蹤速度"), Range(0, 100)]
    public float speed = 1.5f;
    [Header("攝影機下方與上方的限制")]
    public Vector2 limit = new Vector2(0, 3.5f);



    /// <summary>
    /// 追蹤
    /// </summary>
    private void Track()
    {
        Vector3 posA = transform.position;                          //  取得攝影機座標
        Vector3 posB = target.position;                             //  取得目標座標

        posB.z = -10;                                               // 固定 Z 軸
        posB.y = Mathf.Clamp(posB.y, limit.x, limit.y);

        // 一禎的時間  Time.deltaTime

        posA = Vector3.Lerp(posA, posB, speed * Time.deltaTime);    // 插植

        transform.position = posA;                                  // 攝影機 座標 = A 點


    }


    private void LateUpdate()
    {

        Track();


    }












}
