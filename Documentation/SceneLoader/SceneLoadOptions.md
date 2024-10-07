SceneLoadOptions
---
### Description
This struct contains all the scene loading parameters.

### Properties
|||
|-|-|
| **SceneMode** | See [LoadSceneMode](https://docs.unity3d.com/ScriptReference/SceneManagement.LoadSceneMode.html). |
| **PhysicsMode** | See [LocalPhysicsMode](https://docs.unity3d.com/ScriptReference/SceneManagement.LocalPhysicsMode.html). |
| [**ManualActivation**](ManualActivation.md) | A boolean representing whether or not the Scene will be manually or automatically activated. |

### Constructors
public **SceneLoadOptions**([LoadSceneMode](https://docs.unity3d.com/ScriptReference/SceneManagement.LoadSceneMode.html) **mode**);

public **SceneLoadOptions**(bool **manualActivation**);

public **SceneLoadOptions**([LoadSceneMode](https://docs.unity3d.com/ScriptReference/SceneManagement.LoadSceneMode.html) **mode**, bool **manualActivation**);

public **SceneLoadOptions**([LoadSceneMode](https://docs.unity3d.com/ScriptReference/SceneManagement.LoadSceneMode.html) **mode**, [LocalPhysicsMode](https://docs.unity3d.com/ScriptReference/SceneManagement.LocalPhysicsMode.html) **physicsMode**);

public **SceneLoadOptions**([LoadSceneMode](https://docs.unity3d.com/ScriptReference/SceneManagement.LoadSceneMode.html) **mode**, [LocalPhysicsMode](https://docs.unity3d.com/ScriptReference/SceneManagement.LocalPhysicsMode.html) **physicsMode**, bool **manualActivation**);
