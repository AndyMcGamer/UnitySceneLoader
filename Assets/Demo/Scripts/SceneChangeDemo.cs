using UnityEngine;
using UnitySceneLoader.SceneLoading;

namespace UnitySceneLoader.Demo
{
    public class SceneChangeDemo : MonoBehaviour
    {
        public void ChangeScene(string sceneName)
        {
            SceneLoader.instance.LoadScene(sceneName);
        }
    }
}


