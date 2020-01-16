using System.Collections.Generic;
using UnityEngine;

public class ModulesLoader
{
    public static IEnumerable<IModule> GetAll()
    {
        yield return new FirstPersonControllerModule();
    }
}
