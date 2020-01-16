using Assets.Scripts.Framework.Scenes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWorldButton : MonoBehaviour
{
    [SerializeField] private ModulesList _modules;

    public void OnStartButtonClick()
    {
        TypedSceneLoader.Load("World", _modules.EnabledModules);
    }
}
