using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    // ユーザー名の入力テキスト
    public InputField IpfUserName;

    public void OnClickLoginButton()
    {
        // 入力したユーザー名の取得 
        UserLoginData.userName = IpfUserName.text;

        // プレイ画面へ遷移
        SceneManager.LoadScene("PlayScene");
    }

    public void OnClickExitButton()
    {
        Application.Quit();
    }
}