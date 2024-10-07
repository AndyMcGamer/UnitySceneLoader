[SceneLoader](README.md).IsLoadingScene
---
public bool **IsLoadingScene** { get; }
### Description
Whether or not there is currently a Scene being loaded.

Returns true if a scene is currently being loaded ([LoadProgress](LoadProgress.md) is not -1 and there is an active [AsyncOperation](https://docs.unity3d.com/ScriptReference/AsyncOperation.html)), or else returns false.

```csharp
using UnityEngine;

public class Example : MonoBehaviour
{
  void Start()
  {
    Debug.Log(SceneLoader.instance.IsLoadingScene); // false
    SceneLoader.instance.LoadScene("OtherScene");
    Debug.Log(SceneLoader.instance.IsLoadingScene); // true
  }
}
```
