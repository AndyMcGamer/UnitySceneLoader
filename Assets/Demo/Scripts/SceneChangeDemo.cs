using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeDemo : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneLoader.instance.LoadScene(sceneName);
    }
}
