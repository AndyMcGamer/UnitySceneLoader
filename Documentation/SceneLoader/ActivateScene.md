[SceneLoader](README.md).ActivateScene
---
### Declaration
public async void **ActivateScene**(float **delay** = 0f, bool **ignoreTimeScale** = false);

### Parameters
|||
|-|-|
| **delay** | How much time in seconds will the function wait before activating the Scene. |
| **ignoreTimeScale** | Whether to use [Time.deltaTime](https://docs.unity3d.com/ScriptReference/Time-deltaTime.html) or [Time.unscaledDeltaTime](https://docs.unity3d.com/ScriptReference/Time-unscaledDeltaTime.html). |

### Description
Manually activate the scene. This function does nothing if no Scene is currently being loaded.

This function is primarily used when [SceneLoadOptions.ManualActivation](ManualActivation.md) is true. Providing a **delay** greater than 0 will activate the Scene after the specified amount of time has passed.

If the current Scene being loaded has finished, immediately activates the newly loaded Scene. Else, wait for the Scene to finish loading and immediately activate the loaded Scene.
