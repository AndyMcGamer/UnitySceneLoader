using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;

    private float _loadProgress = -1f;
    public float LoadProgress { get => _loadProgress; private set => _loadProgress = value; }

    public static event Action<float> OnLoadUpdate;

    private AsyncOperation _loadOperation = null;
    public AsyncOperation LoadOperation { get => _loadOperation; private set => _loadOperation = value; }

    public bool IsLoadingScene => _loadOperation != null || _loadProgress >= 0f;

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
    /// <param name="sceneName">The name of the scene.</param>
    public void LoadScene(string sceneName, LoadSceneMode sceneMode = LoadSceneMode.Single)
    {
        SceneLoadOptions loadOptions = new(sceneMode);
        StartCoroutine(LoadSceneAsync(sceneName, loadOptions));
    }

    /// <summary>
    /// Loads the specified scene.
    /// </summary>
    /// <param name="index">The build index of the scene.</param>
    public void LoadScene(int index, LoadSceneMode sceneMode = LoadSceneMode.Single)
    {
        SceneLoadOptions loadOptions = new(sceneMode);
        var sceneName = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(index));
        StartCoroutine(LoadSceneAsync(sceneName, loadOptions));
    }

    /// <summary>
    /// Loads the specified scene.
    /// </summary>
    /// <param name="sceneName">The name of the scene.</param>
    /// <param name="loadOptions">The options for loading the scene. NOTE: If ManualActivation is true, you must call SceneLoader.ActivateScene.</param>
    public void LoadScene(string sceneName, SceneLoadOptions loadOptions)
    {
        StartCoroutine(LoadSceneAsync(sceneName, loadOptions));
    }

    /// <summary>
    /// Loads the specified scene.
    /// </summary>
    /// <param name="index">The build index of the scene.</param>
    /// <param name="loadOptions">The options for loading the scene. NOTE: If ManualActivation is true, you must call SceneLoader.ActivateScene.</param>
    public void LoadScene(int index, SceneLoadOptions loadOptions)
    {
        var sceneName = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(index));
        StartCoroutine(LoadSceneAsync(sceneName, loadOptions));
    }

    private IEnumerator LoadSceneAsync(string sceneName, SceneLoadOptions loadOptions)
    {
        LoadSceneParameters sceneParameters = new(loadOptions.SceneMode, loadOptions.PhysicsMode);
        _loadOperation = SceneManager.LoadSceneAsync(sceneName, sceneParameters);

        _loadOperation.allowSceneActivation = false;
        _loadProgress = 0f;

        while (!_loadOperation.isDone)
        {
            _loadProgress = _loadOperation.progress / 0.9f;
            OnLoadUpdate?.Invoke(LoadProgress);

            if(_loadOperation.progress >= 0.9f)
            {
                if (!loadOptions.ManualActivation) _loadOperation.allowSceneActivation = true;
            }

            yield return null;
        }

        _loadProgress = -1f;
        _loadOperation = null;
    }

    /// <summary>
    /// Manually activate the scene. Used when SceneLoadOptions.ManualActivation is true.
    /// </summary>
    /// <param name="delay">Amount of time to wait before activation.</param>
    /// <param name="ignoreTimeScale">Whether to use scaled or unscaled time.</param>
    public async void ActivateScene(float delay = 0f, bool ignoreTimeScale = false)
    {
        if (_loadOperation == null) return;

        var elapsedTime = 0f;
        while(elapsedTime < delay)
        {
            elapsedTime += ignoreTimeScale ? Time.unscaledDeltaTime : Time.deltaTime;
            await Task.Yield();
        }

        _loadOperation.allowSceneActivation = true;
    }

    /// <summary>
    /// Unloads the specified scene.
    /// </summary>
    /// <param name="sceneName">The name of the scene.</param>
    public void UnloadScene(string sceneName)
    {
        StartCoroutine(UnloadSceneAsync(sceneName));
    }

    /// <summary>
    /// Unloads the specified scene.
    /// </summary>
    /// <param name="index">The build index of the scene.</param>
    public void UnloadScene(int index)
    {
        var sceneName = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(index));
        StartCoroutine(UnloadSceneAsync(sceneName));
    }

    private IEnumerator UnloadSceneAsync(string sceneName)
    {
        AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(sceneName);
        while (!asyncUnload.isDone)
        {
            yield return null;
        }
    }
}
