using System.Collections;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// Loads the specified scene.
    /// </summary>
    /// <param name="sceneName"></param>
    public void LoadScene(string sceneName, UnityEngine.SceneManagement.LoadSceneMode sceneMode = UnityEngine.SceneManagement.LoadSceneMode.Single)
    {
        StartCoroutine(LoadSceneAsync(sceneName, sceneMode));
    }

    /// <summary>
    /// Loads the specified scene.
    /// </summary>
    /// <param name="index"></param>
    public void LoadScene(int index, UnityEngine.SceneManagement.LoadSceneMode sceneMode = UnityEngine.SceneManagement.LoadSceneMode.Single)
    {
        var sceneName = System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(index));
        StartCoroutine(LoadSceneAsync(sceneName, sceneMode));
    }

    private IEnumerator LoadSceneAsync(string sceneName, UnityEngine.SceneManagement.LoadSceneMode sceneMode)
    {
        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName, sceneMode);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    /// <summary>
    /// Unloads the specified scene.
    /// </summary>
    /// <param name="sceneName"></param>
    public void UnloadScene(string sceneName)
    {
        StartCoroutine(UnloadSceneAsync(sceneName));
    }

    /// <summary>
    /// Unloads the specified scene.
    /// </summary>
    /// <param name="index"></param>
    public void UnloadScene(int index)
    {
        var sceneName = System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(index));
        StartCoroutine(UnloadSceneAsync(sceneName));
    }

    private IEnumerator UnloadSceneAsync(string sceneName)
    {
        AsyncOperation asyncUnload = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName);
        while (!asyncUnload.isDone)
        {
            yield return null;
        }
    }
}
