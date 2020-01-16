using System;
using System.Collections;
using UnityEngine;

class FirstPersonControllerModule : IModule
{
    private readonly string _basePath;

    public FirstPersonControllerModule() => _basePath = this.GetType().Name;

    public string Name => "Управление от первого лица";

    public IEnumerator Load()
    {
        var controller = Resources.Load<GameObject>($"{_basePath}/FPSController");
        GameObject.Instantiate(controller, new Vector3(0, 2, 0), Quaternion.identity);

        yield return null;
    }

    public IEnumerator Unload()
    {
        throw new NotImplementedException();
    }
}
