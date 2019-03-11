using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using SharedCore;

namespace RocketJump {
  [UpdateAfter(typeof(UnityEngine.Experimental.PlayerLoop.FixedUpdate))]
  public class CameraTrackingSystem : ComponentSystem {
    ComponentGroup camera;
    ComponentGroup player;

    protected override void OnCreateManager () {
      camera = GetComponentGroup(
        typeof(Camera),
        typeof(Transform),
        typeof(PositionOffset),
        typeof(TrackingSpeed)
      );
      player = GetComponentGroup(
        typeof(Position)
      );

      RequireForUpdate(camera);
      RequireForUpdate(player);
    }

    protected override void OnUpdate () {
      var c_entity = camera.GetEntityArray();
      var c_transform = camera.GetTransformAccessArray();
      var c_positionOffset = camera.GetComponentDataArray<PositionOffset>();
      var c_trackingSpeed = camera.GetComponentDataArray<TrackingSpeed>();

      var p_position = player.GetComponentDataArray<Position>();

      c_transform[0].position = Vector3.Lerp(
        c_transform[0].position,
        c_positionOffset[0].Value + p_position[0].Value,
        c_trackingSpeed[0].Value * Time.fixedDeltaTime
      );
    }
  }
}