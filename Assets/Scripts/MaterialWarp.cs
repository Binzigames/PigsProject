using System;
using System.Collections.Generic;
using UnityEngine;

public class MaterialWarp : MonoBehaviour
{
    private readonly int _sideBendID = Shader.PropertyToID("_SidewaysBend");
    private readonly int _backBendID = Shader.PropertyToID("_BackBend");

    [SerializeField]
    private Material _warpMaterial;

    [SerializeField]
    [Range(-1, 1)]
    private float _sidewaysBend = 0f;

    [SerializeField]
    [Range(-1, 1)]
    private float _backBend = 0f;

    [SerializeField]
    private List<Material> _warpedMaterialsList = new List<Material>();

    private void Update()
    {
        if (_warpedMaterialsList != null)
        {
            for (int i = 0; i < _warpedMaterialsList.Count; i++)
            {
                SetSidewayBendInMaterial(_warpedMaterialsList[i], _sidewaysBend);
                SetBackBendInMaterial(_warpedMaterialsList[i], _backBend);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent<MeshRenderer>(out var meshRenderer);
        if (meshRenderer == null)
        {
            var meshRenderers = other.GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i < meshRenderers.Length; i++)
            {
                meshRenderer = meshRenderers[i];
                foreach (var material in meshRenderer.materials)
                {
                    Shader outlineShader = Shader.Find("Shader Graphs/Outline");
                    bool isShaderOutline =
                            material.shader == outlineShader;

                    if (material.parent == null && !isShaderOutline)
                    {
                        material.parent = _warpMaterial;
                    }
                    _warpedMaterialsList.Add(material);
                }
            }
        }

        foreach (var material in meshRenderer.materials)
        {
            Shader outlineShader = Shader.Find("Shader Graphs/Outline");
            bool isShaderOutline =
                    material.shader == outlineShader;

            if (material.parent == null && !isShaderOutline)
            {
                material.parent = _warpMaterial;
            }
            _warpedMaterialsList.Add(material);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.TryGetComponent<MeshRenderer>(out var meshRenderer);
        if (meshRenderer != null)
        {
            var material = meshRenderer.material;
            if (_warpedMaterialsList.Contains(material))
            {
                ResetProperties(material);
                _warpedMaterialsList.Remove(material);
            }
        }
        else
        {
            var meshRenderers = other.GetComponentsInChildren<MeshRenderer>();
            foreach (var mr in meshRenderers)
            {
                var materials = mr.materials;
                foreach (var material in materials)
                {
                    if (_warpedMaterialsList.Contains(material))
                    {
                        ResetProperties(material);
                        _warpedMaterialsList.Remove(material);
                    }
                }
            }
        }
    }

    private void SetSidewayBendInMaterial(Material material, float value)
    {
        material.SetFloat(_sideBendID, value * 0.01f);
    }

    private void SetBackBendInMaterial(Material material, float value)
    {
        material.SetFloat(_backBendID, value * 0.01f);
    }

    private void ResetProperties(Material material)
    {
        SetSidewayBendInMaterial(material, 0);
        SetBackBendInMaterial(material, 0);
    }
}
