[SceneLoadOptions](SceneLoadOptions.md).ManualActivation
---
public bool **ManualActivation** { get; }

### Description
A boolean representing whether or not the Scene will be manually or automatically activated.

This property controls whether or not [SceneLoader](README.md) will [allow Scene activation](https://docs.unity3d.com/ScriptReference/AsyncOperation-allowSceneActivation.html).

If this value is set to true when loading a Scene, [SceneLoader.ActivateScene](ActivateScene.md) *must* be called to properly load the scene.
