using Unity.Cinemachine;
using UnityEngine;

public class LockCameraY : CinemachineExtension
{
    [SerializeField] private float _lockCameraYPos;

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage,
        ref CameraState state,
        float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Finalize)
        {
            var pos = state.RawPosition;
            pos.y = _lockCameraYPos;
            state.RawPosition = pos;
        }
    }

}
