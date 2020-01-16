using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IModule
{
    string Name { get; }

    IEnumerator Load();
    IEnumerator Unload();
}
