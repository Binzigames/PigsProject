using UnityEngine;

public class MaterialWarp : MonoBehaviour
{
    private readonly int _sideBendID = Shader.PropertyToID("_SidewaysBend");
    private readonly int _backBendID = Shader.PropertyToID("_BackBend");

    [SerializeField]
    private Material[] _warpMaterials;

    [SerializeField]
    [Range(-0.001f, 0.001f)]
    private float _sidewaysBend = 0f;

    [SerializeField]
    [Range(-0.001f, 0.001f)]
    private float _backBend = 0f;

    private float _currentSideBend;
    private float _currentBackBend;

    private void Awake()
    {
        BendAllMaterials(_sidewaysBend, _backBend);
    }

    private void Update()
    {
        if (IsBendValueWasChanged())
        {
            BendAllMaterials(_sidewaysBend, _backBend);
        }
    }

    private void BendAllMaterials(float sideBend, float backBend)
    {
        for (int i = 0; i < _warpMaterials.Length; i++)
        {
            _warpMaterials[i].SetFloat(_sideBendID, sideBend);
            _warpMaterials[i].SetFloat(_backBendID, backBend);
        }
        _currentSideBend = sideBend;
        _currentBackBend = backBend;
    }

    private bool IsBendValueWasChanged()
    {
        return _currentSideBend != _sidewaysBend || _currentBackBend != _backBend;
    }

}
