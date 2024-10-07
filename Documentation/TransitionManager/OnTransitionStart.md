[TransitionManager](README.md).OnTransitionStart
---
public static event Action **OnTransitionStart**;
### Description
Subscribe to this event to get notified when a transition starts.

```csharp
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
  private void OnEnable()
  {
    TransitionManager.OnTransitionStart += TransitionStarted;
  }

  private void OnDisable()
  {
    TransitionManager.OnTransitionStart -= TransitionStarted;
  }

  private void TransitionStarted()
  {
    Debug.Log("Transition Started");
  }
}
```
