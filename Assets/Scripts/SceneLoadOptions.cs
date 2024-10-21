using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnitySceneLoader.SceneLoading
{
    /// <summary>
    /// This struct contains all the scene loading parameters.
    /// </summary>
    [Serializable]
    public struct SceneLoadOptions
    {
        [SerializeField] private LoadSceneMode _sceneMode;
        [SerializeField] private LocalPhysicsMode _physicsMode;
        [SerializeField] private bool _manualActivation;

        /// <summary>
        /// See Unity LoadSceneMode.
        /// </summary>
        public LoadSceneMode SceneMode { get { return _sceneMode; } set { _sceneMode = value; } }

        /// <summary>
        /// See Unity LocalPhysicsMode.
        /// </summary>
        public LocalPhysicsMode PhysicsMode { get { return _physicsMode; } set { _physicsMode = value; } }

        /// <summary>
        /// Whether or not the scene should be manually activated.
        /// </summary>
        public bool ManualActivation { get { return _manualActivation; } set { _manualActivation = value; } }

        public SceneLoadOptions(LoadSceneMode mode)
        {
            _sceneMode = mode;
            _physicsMode = LocalPhysicsMode.None;
            _manualActivation = false;
        }

        public SceneLoadOptions(bool manualActivation)
        {
            _manualActivation = manualActivation;
            _physicsMode = LocalPhysicsMode.None;
            _sceneMode = LoadSceneMode.Single;
        }

        public SceneLoadOptions(LoadSceneMode mode, bool manualActivation)
        {
            _sceneMode = mode;
            _manualActivation = manualActivation;
            _physicsMode = LocalPhysicsMode.None;
        }

        public SceneLoadOptions(LoadSceneMode mode, LocalPhysicsMode physicsMode)
        {
            _sceneMode = mode;
            _physicsMode = physicsMode;
            _manualActivation = false;
        }

        public SceneLoadOptions(LoadSceneMode mode, LocalPhysicsMode physicsMode, bool manualActivation)
        {
            _sceneMode = mode;
            _physicsMode = physicsMode;
            _manualActivation = manualActivation;
        }
    }

}