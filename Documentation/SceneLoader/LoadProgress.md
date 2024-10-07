LoadProgress
===
public float **LoadProgress** { get; private set; }
### Description
The current progress of the scene loading. 

Returns a float representing the scene loading progress, normalized on the interval [0,1]. Returns -1 if no scene is currently being loaded.

```csharp
using UnityEngine;

public class Example : MonoBehaviour
{
  void Start()
  {
    SceneLoader.instance.LoadScene("OtherScene");
  }

  void Update()
  {
    Debug.Log($"Current Loading Progress: {SceneLoader.instance.LoadProgress}");
  }
}
```
