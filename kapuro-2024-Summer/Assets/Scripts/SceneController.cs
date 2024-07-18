using UnityEngine.SceneManagement;
using UnityEngine;

//シーン遷移を行うクラス
public static class SceneController
{
    public static AsyncOperation ChangeSceneAsync(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
        return new AsyncOperation();
    }
}