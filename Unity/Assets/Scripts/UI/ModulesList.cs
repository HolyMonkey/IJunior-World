using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ModulesList : MonoBehaviour
{
    [SerializeField] private ModulePresenter _template;
    [SerializeField] private Transform _container;

    private List<IModule> _enabledModules;

    public IEnumerable<IModule> EnabledModules => _enabledModules;

    private void Awake()
    {
        Present(ModulesLoader.GetAll());
    }

    private void Present(IEnumerable<IModule> modules)
    {
        _enabledModules = new List<IModule>(modules.Count());

        foreach (var module in modules)
        {
            var presenter = Instantiate(_template, _container) as ModulePresenter;
            presenter.Present(module, (enabled) => {
                if (enabled)
                    _enabledModules.Add(module);
                else
                    _enabledModules.Remove(module);
            });
        }
    }
}
