using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Framework.Scenes
{
    class TypedSceneLoader
    {
        public static void Load<T>(string name, T argument)
        {
            UnityAction<Scene, Scene> changedHandler = null;
            changedHandler = (from, to) =>
            {
                if (to.name == name)
                {
                    SceneManager.activeSceneChanged -= changedHandler;
                    foreach(var root in to.GetRootGameObjects())
                    {
                        foreach (var handler in root.GetComponentsInChildren<ISceneLoadHandler<T>>())
                        {
                            handler.OnSceneLoad(argument);
                        }
                    }
                }
            };

            SceneManager.activeSceneChanged += changedHandler;
            SceneManager.LoadScene(name);
        }
    }
}
