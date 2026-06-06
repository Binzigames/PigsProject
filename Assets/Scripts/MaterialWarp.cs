using System;
using UnityEngine;

public class MaterialWarp : MonoBehaviour
{
    private readonly int _sideBendID = Shader.PropertyToID("_SidewaysBend");
    private readonly int _backBendID = Shader.PropertyToID("_BackBend");

    [SerializeField]
    private Material[] _warpMaterials;

    [SerializeField]
    [Range(-1, 1)]
    private float _sidewaysBend = 0f;
    private float _currentSideBend;

    [SerializeField]
    [Range(-1, 1)]
    private float _backBend = 0f;
    private float _currentBackBend;

    private void Update()
    {
        if (IsBendValueWasChanged())
        {
            Debug.Log("is changed");
            for (int i = 0; i < _warpMaterials.Length; i++)
            {
                _warpMaterials[i].SetFloat(_sideBendID, _sidewaysBend * 0.01f);
                _warpMaterials[i].SetFloat(_backBendID, _backBend * 0.01f);
            }
            _currentSideBend = _sidewaysBend;
            _currentBackBend = _backBend;
        }
    }

    private bool IsBendValueWasChanged()
    {
        return _currentSideBend != _sidewaysBend ||
                        _currentBackBend != _backBend;
    }

}
