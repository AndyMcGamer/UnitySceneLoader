TransitionType
---

### Description
Used when executing a transition.

Use TransitionType to specify the transition effect that is when calling a transition using [TransitionManager.Transition](Transition.md). 

```csharp
using UnityEngine;
using PrimeTween;

public class Example : MonoBehaviour
{
  async void Start()
  {
    // Executes a screen wipe from left to right, stopping in the middle.
    await TransitionManager.instance.Transition(TransitionType.WipeLeftIn, 0.75f, Ease.InOutSine, true, false);

    // Executes a fade-out effect.
    await TransitionManager.instance.Transition(TransitionType.FadeOut, 0.75f, Ease.InOutSine, true, false);
  }
}
```

### Properties
|||
| - | - |
| FadeIn | Fullscreen fade-in effect. |
| FadeOut | Fullscreen fade-out effect. |
| FadeInOut | Fullscreen fade-in effect, immediately followed by a fade-out effect. |
| WipeLeftIn        | Screen wipe from left to right, stopping in the middle. |
| WipeLeftOut       | Screen wipe from left to right, starting from the middle. |
| WipeLeftInOut     | Screen wipe from left to right. |
| WipeRightIn       | Screen wipe from right to left, stopping in the middle. |
| WipeRightOut      | Screen wipe from right to left, starting from the middle. |
| WipeRightInOut    | Screen wipe from right to left. |
| WipeUpIn          | Screen wipe from bottom to top, stopping in the middle. |
| WipeUpOut         | Screen wipe from bottom to top, starting from the middle. |
| WipeUpInOut       | Screen wipe from bottom to top. |
| WipeDownIn        | Screen wipe from top to bottom, stopping in the middle. |
| WipeDownOut       | Screen wipe from top to bottom, starting from the middle. |
| WipeDownInOut     | Screen wipe from top to bottom. |
