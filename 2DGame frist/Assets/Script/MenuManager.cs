using UnityEngine;
using UnityEngine.SceneManagement;  //引用 場景管理 API

public class MenuManager : MonoBehaviour
{
    /// <summary>
    /// 開始遊戲
    /// </summary>
    public void StartGame()
    {
        // 場景管理 的 載入場景("關卡名稱")
        SceneManager.LoadScene("關卡");
    }

    /// <summary>
    /// 離開遊戲
    /// </summary>
    public void QuitGame()
    {
        // 應用程式 的 離開遊戲
        Application.Quit();
    }
}
