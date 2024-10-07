[TransitionManager](README.md).OnTransitionEnd
---
public static event Action **OnTransitionEnd**;
### Description
Subscribe to this event to get notified when a transition ends.

```csharp
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
  private void OnEnable()
  {
    TransitionManager.OnTransitionEnd += TransitionEnded;
  }

  private void OnDisable()
  {
    TransitionManager.OnTransitionEnd -= TransitionEnded;
  }

  private void TransitionEnded()
  {
    Debug.Log("Transition Ended");
  }
}
```
