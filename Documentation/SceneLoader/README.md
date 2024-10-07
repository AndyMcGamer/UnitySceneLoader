SceneLoader
===

### Description
Singleton class used for loading Scenes.

### Properties
|||
| - | - |
| instance | The static singleton instance. |
| LoadProgress | The current progress of the scene loading. |
| LoadOperation | A reference to the current scene loading's [AsyncOperation](https://docs.unity3d.com/ScriptReference/AsyncOperation.html). |
| IsLoadingScene | Whether or not there is currently a Scene being loaded. |

### Methods
|||
| - | - |
| [LoadScene](LoadScene.md) | Loads a Scene by the specified name or build index. |

### Events
|||
|-|-|
| [OnLoadUpdate] | Subscribe to this event to get notified when the LoadProgress changes. |
