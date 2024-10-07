SceneLoadOptions
---
### Description
This struct contains all the scene loading parameters.

### Properties
|||
|-|-|
| **sceneMode** | See [LoadSceneMode](https://docs.unity3d.com/ScriptReference/SceneManagement.LoadSceneMode.html). |
| **physicsMode** | See [LocalPhysicsMode](https://docs.unity3d.com/ScriptReference/SceneManagement.LocalPhysicsMode.html). |
| [manualActivation](ManualActivation.md) | A boolean representing whether or not the Scene will be manually or automatically activated. |

### Constructor
public **SceneLoadOptions**([LoadSceneMode](https://docs.unity3d.com/ScriptReference/SceneManagement.LoadSceneMode.html). **mode**);
### Constructor
public **SceneLoadOptions**(bool **manualActivation**);
### Constructor
public **SceneLoadOptions**([LoadSceneMode](https://docs.unity3d.com/ScriptReference/SceneManagement.LoadSceneMode.html) **mode**, bool **manualActivation**);
### Constructor
public **SceneLoadOptions**([LoadSceneMode](https://docs.unity3d.com/ScriptReference/SceneManagement.LoadSceneMode.html) **mode**, [LocalPhysicsMode](https://docs.unity3d.com/ScriptReference/SceneManagement.LocalPhysicsMode.html) **physicsMode**);
### Constructor
public **SceneLoadOptions**([LoadSceneMode](https://docs.unity3d.com/ScriptReference/SceneManagement.LoadSceneMode.html) **mode**, [LocalPhysicsMode](https://docs.unity3d.com/ScriptReference/SceneManagement.LocalPhysicsMode.html) **physicsMode**, bool **manualActivation**);
