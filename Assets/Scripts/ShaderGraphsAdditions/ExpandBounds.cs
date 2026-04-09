using UnityEngine;

public class ExpandBounds : MonoBehaviour
{
    public float expand = 500f;

    void Start()
    {
        ApplyToChildren();
    }

    void ApplyToChildren()
    {
        var meshFilters = GetComponentsInChildren<MeshFilter>();

        foreach (var mf in meshFilters)
        {
            if (mf.sharedMesh != null)
            {
                var mesh = mf.mesh;
                mesh.bounds = new Bounds(Vector3.zero, Vector3.one * expand);
            }
        }


        var skinnedMeshes = GetComponentsInChildren<SkinnedMeshRenderer>();

        foreach (var smr in skinnedMeshes)
        {
            if (smr.sharedMesh != null)
            {
                smr.localBounds = new Bounds(Vector3.zero, Vector3.one * expand);
                smr.updateWhenOffscreen = true; 
            }
        }
    }
}