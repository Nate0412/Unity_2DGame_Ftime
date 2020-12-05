using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        SetCollision();
    }

    /// <summary>
    /// 設定碰撞:所有圖層的碰撞
    /// </summary>
    private void SetCollision()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("玩家"), LayerMask.NameToLayer("玩家子彈"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("敵人"), LayerMask.NameToLayer("敵人子彈"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("敵人子彈"), LayerMask.NameToLayer("玩家子彈"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("敵人子彈"), LayerMask.NameToLayer("敵人子彈"));

    }


}
