SceneLoader
===

### Description
Singleton class used for loading Scenes.

### Properties
|||
| - | - |
| [LoadProgress](LoadProgress.md) | The current progress of the scene loading. |
| [IsLoadingScene](IsLoadingScene.md) | Whether or not there is currently a Scene being loaded. |
<!--| LoadOperation | A reference to the current scene loading's [AsyncOperation](https://docs.unity3d.com/ScriptReference/AsyncOperation.html). |-->

### Methods
|||
| - | - |
| [LoadScene](LoadScene.md) | Loads a Scene by the specified name or build index. |

### Events
|||
|-|-|
| [OnLoadUpdate](OnLoadUpdate.md) | Subscribe to this event to get notified when LoadProgress changes. |
