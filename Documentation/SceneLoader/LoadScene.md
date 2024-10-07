SceneLoader.LoadScene
---
### Declaration
public void **LoadScene**(string **sceneName**, [LoadSceneMode](https://docs.unity3d.com/ScriptReference/SceneManagement.LoadSceneMode.html) **sceneMode** = LoadSceneMode.Single)
### Declaration
public void **LoadScene**(int **index**, [LoadSceneMode](https://docs.unity3d.com/ScriptReference/SceneManagement.LoadSceneMode.html) **sceneMode** = LoadSceneMode.Single)
### Declaration
public void **LoadScene**(string **sceneName**, [SceneLoadOptions] **loadOptions**)
### Declaration
public void **LoadScene**(int **index**, [SceneLoadOptions] **loadOptions**)

### Parameters

| | |
| --- | --- |
| **sceneName** | The name or path of the Scene to load. |
| **index**     | The build index of the Scene to load. |
| **sceneMode** | Whether or not to load the Scene additively. See [LoadSceneMode](https://docs.unity3d.com/ScriptReference/SceneManagement.LoadSceneMode.html) for details. |
| **loadOptions** | Various parameters used to load the Scene. See [] for details. |

### Description
Loads the Scene by its name or build index.

Under the hood, this function uses [LoadSceneAsync](https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadSceneAsync.html) to load scenes. More details can be found in the [Unity documentation](https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadSceneAsync.html). The non-async version can be found [here](https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadScene.html).

To check loading progress, use the LoadProgress property.

```csharp
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExampleClass : MonoBehaviour
{
  void LoadSceneExample()
  {
    // Only specifying the sceneName or index will load the Scene with the Single mode
    SceneLoader.instance.LoadScene("OtherScene", LoadSceneMode.Additive);
  }

  void LoadSceneWithOptionsExample()
  {
    // Note: when ManualActivation is set to true, you must call SceneLoader.ActivateScene to trigger the scene change.
    SceneLoadOptions loadOptions = new(LoadSceneMode.Single, LocalPhysicsMode.None, true);
    SceneLoader.instance.LoadScene(1, loadOptions);
  }
}
```
