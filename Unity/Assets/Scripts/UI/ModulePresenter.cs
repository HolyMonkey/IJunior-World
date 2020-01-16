using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ModulePresenter : MonoBehaviour
{
    [SerializeField] private Text _label;
    [SerializeField] private Toggle _toggle;

    private Action<bool> _onToggle;

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(OnToggle);
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(OnToggle);
    }

    public void Present(IModule module, Action<bool> onToggle)
    {
        _label.text = module.Name;
        _onToggle = onToggle;
    }

    private void OnToggle(bool value)
    {
        _onToggle?.Invoke(value);
    }
}
