[TransitionManager](README.md).Transition
---
### Declaration
public async Task Transition([TransitionType](TransitionType.md) **type** = TransitionType.FadeInOut, float **time** = 0.5f, [Ease]() **ease** = Ease.Linear, bool **reset** = true, bool **ignoreTimeScale** = false);
### Declaration
public async Task Transition([TransitionType](TransitionType.md) **type**, float **time**, [Ease]() **ease**, bool **reset**, [Color](https://docs.unity3d.com/ScriptReference/Color.html) **color**, bool **ignoreTimeScale** = false);

### Parameters
| | |
| --- | --- |
| **type** | The type of transition. See [TransitionType](TransitionType.md) for details. |
| **time** | The total duration of the transition in seconds. |
| **ease** | The ease function to use. See [Ease]() for details. |
| **reset** | Whether or not to force the transition to start from the very beginning. |
| **ignoreTimeScale** | Determines whether or not the transition will execute with unscaled time. |
| **color** | What color the transition image will be. |

### Description
Executes a transition with the specified settings.

```csharp
using UnityEngine;
using PrimeTween;
using System.Threading.Tasks;

public class Example : MonoBehaviour
{
  void Start()
  {
    // If we don't need the async/await functionality we can capture it in a Task, though this is not recommended.
    Task _ = TransitionManager.instance.Transition(TransitionType.FadeOut, 0.75f, Ease.InOutSine, true, false);
  }
}
```
