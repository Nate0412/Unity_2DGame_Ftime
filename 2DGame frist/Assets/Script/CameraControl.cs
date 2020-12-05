using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("目標")]
    public Transform target;
    [Header("追蹤速度"), Range(0, 100)]
    public float speed = 1.5f;
    [Header("攝影機下方與上方的限制")]
    public Vector2 limit = new Vector2(0, 3.5f);




    private void Track()
    {
        Vector3 posA = transform.position;                          //
        Vector3 posB = transform.position;                          //

        posB.z = -10;                                               // 固定 Z 軸

        //

        posA = Vector3.Lerp(posA, posB, speed * Time.deltaTime);    // 插植

        transform.position = posA;                                  // 攝影機 座標 = A 點


    }















}
