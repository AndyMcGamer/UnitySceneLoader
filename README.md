**NOTE:** This is part of a larger set of tools that provide the generic functionality needed in various Unity projects.

UnitySceneLoader
===
Barebones Scene Loader Implementation for Unity. This repo includes scripts for handling Scene loading and screen transitions/effects. Some samples have also been included to demonstrate usage.

## Third-Party Dependencies
In order for the `TransitionManager` to work, the [`PrimeTween`](#primetween) asset must be installed from the [Unity Asset Store](https://assetstore.unity.com/packages/tools/animation/primetween-high-performance-animations-and-sequences-252960).

## Core Scripts and Objects
This section will detail the key scripts and objects that are used and their purpose.

### [SceneLoader](Documentation/SceneLoader/README.md)
Derives from `MonoBehaviour`. This class follows the singleton design pattern and handles Scene loading. This class is intended to persist between Scenes and can be used to switch Scenes whenever needed.

#### **Usage:**
This script should be placed on a GameObject in the starting Scene. It will be moved to `DontDestroyOnLoad` on Play. To change Scenes, use the [SceneLoader.LoadScene](Documentation/SceneLoader/LoadScene.md) function.

### [TransitionManager](Documentation/TransitionManager/README.md)
Derives from `MonoBehaviour`. This class follows the singleton design pattern and handles screen transition effects. This class is intended to persist between Scenes and can be used for effects such as full-screen fading and wipes.

#### **Usage:**
This script should be placed on a GameObject in the starting Scene. It will be moved to `DontDestroyOnLoad` on Play. To execute a transition, use the [TransitionManager.Transition](Documentation/TransitionManager/Transition.md) function.

### Dependencies
Here is the dependency graph for the core scripts.

![Imgur](https://i.imgur.com/eq1M2Ec.png)

## Demos
Included with this project are two demos: one for Scene loading and one for transitions. These demos can be found by opening the `DemoScene1`/`DemoScene2` and `TransitionDemo` Scenes, respectively.

### Scene Loading Demo
This demo is a combination of two scenes that have both been added to the build settings. Entering Play Mode and pressing the button in the middle will change the current scene using the `ChangeSceneDemo` class.

Inside the script `ChangeSceneDemo.cs`, there is a simple example of how to use the [SceneLoader](Documentation/SceneLoader/README.md) to load a new scene.

### Transition Demo
This demo allows the user to preview all the different types of transitions with various setting combinations. 

Entering Play Mode and pressing the button labeled "Transition" will execute the transition. To change the transition settings, including the transition type, select the `TransitionSettings` GameObject in the hierarchy and change the values of the exposed fields.

Inside the script `TransitionDemo.cs`, there is a simple example of how to use [TransitionManager](Documentation/TransitionManager/README.md) to execute a transition.

### Class Dependencies
Here is a graph for the class dependencies of the demo scripts.
![Imgur](https://i.imgur.com/L3VcIBn.png)

## PrimeTween
[PrimeTween](https://assetstore.unity.com/packages/tools/animation/primetween-high-performance-animations-and-sequences-252960) is a free, non-allocating Tween library that is very easy to work with. The `TransitionManager` class depends on this package being installed as all the effects are done in code via tweening.

Check out the [GitHub repository](https://github.com/KyryloKuzyk/PrimeTween) where there is detailed documentation on how to use the library.
