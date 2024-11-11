using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    // シーンをロードする関数
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // シーンをリロードする（再読み込み）関数
    public void ReloadCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}