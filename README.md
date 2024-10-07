**NOTE:** This is part of a larger set of tools that provide the generic functionality needed in various Unity projects.

UnitySceneLoader
===
Barebones Scene Loader Implementation for Unity. This repo includes scripts for handling scene loading and screen transitions/effects. Some samples have also been included to demonstrate usage.

## Third-Party Dependencies
In order for the `TransitionManager` to work, the [`PrimeTween`](#primetween) asset must be installed from the [Unity Asset Store](https://assetstore.unity.com/packages/tools/animation/primetween-high-performance-animations-and-sequences-252960).

## Core Scripts and Objects
This section will detail the key scripts and objects that are used and their purpose.

### SceneLoader
Derives from `MonoBehaviour`. This class follows the singleton design pattern and handles scene loading. This class is intended to persist between scenes and can be used to switch scenes whenever needed.

#### **Usage:**
This script should be placed on a GameObject in the starting scene. It will be moved to `DontDestroyOnLoad` on Play. To change scenes, use the `SceneLoader.LoadScene` function.

### TransitionManager
Derives from `MonoBehaviour`. This class follows the singleton design pattern and handles screen transition effects. This class is intended to persist between scenes and can be used for effects such as full-screen fading and wipes.

#### **Usage:**
This script should be placed on a GameObject in the starting scene. It will be moved to `DontDestroyOnLoad` on Play. To execute a transition, use the `TransitionManager.Transition` function.


## PrimeTween
`PrimeTween` is a free, non-allocating Tween library that is very easy to work with. The `TransitionManager` class depends on this package being installed as all the effects are done in code via tweening.

Check out the [GitHub repository](https://github.com/KyryloKuzyk/PrimeTween) where there is detailed documentation on how to use the library.
