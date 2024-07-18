using System.Collections;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadController : MonoBehaviour
{
    [SerializeField] private GameObject loadingUI;
    [SerializeField] private Slider slider;

    private bool isLoading = false;

    public void Initialize()
    {
        
    }

    public void UpdateLoadController()
    {
        
    }

    public async void LoadNextScene()
    {
        if (CheckLoading())
            return;

        isLoading = true;
        loadingUI.SetActive(true);
        await LoadScene();
    }
    
    private bool CheckLoading()
    {
        return isLoading;
    }

    private IEnumerator LoadScene()
    {
        AsyncOperation async = SceneController.ChangeSceneAsync("next");
        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            slider.value = async.progress;
            
            if (async.progress >= 0.9f)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    async.allowSceneActivation = true;
                }
            }
            
            yield return UniTask.ToCoroutine(null);
        }
    }
}
