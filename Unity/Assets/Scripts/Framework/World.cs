using Assets.Scripts.Framework.Scenes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour, ISceneLoadHandler<IEnumerable<IModule>>
{
    public void Create(IEnumerable<IModule> modules)
    {
        StartCoroutine(LoadModules(modules));
    }

    public void OnSceneLoad(IEnumerable<IModule> argument)
    {
        Create(argument);
    }

    private IEnumerator LoadModules(IEnumerable<IModule> modules)
    {
        foreach (var module in modules)
            yield return StartCoroutine(module.Load());
    }
}
