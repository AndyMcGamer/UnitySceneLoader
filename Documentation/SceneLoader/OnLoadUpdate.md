OnLoadUpdate
===
public static event Action<float> **OnLoadUpdate**;
### Parameters
| | |
| - | - |
| value | Use a subscription of a method that takes in a float argument. |

### Description
Subscribe to this event to get notified when LoadProgress changes.

While an active scene load is happening, this event will be invoked, sending the current progress of the scene loading.

This script sets an Image object's fill amount to be aligned with the progress.
```csharp
using UnityEngine;
using UnityEngine.UI;

public class ExampleScript : MonoBehaviour
{
  [SerializeField] private Image image;

  private void OnEnable()
  {
    SceneLoader.OnLoadUpdate += LoadUpdated;
  }

  private void OnDisable()
  {
    SceneLoader.OnLoadUpdate -= LoadUpdated;
  }

  private void LoadUpdated(float progress)
  {
    image.fillAmount = progress;
  }
}
```
