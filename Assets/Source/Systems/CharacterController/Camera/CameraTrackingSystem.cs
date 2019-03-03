using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump {
  [UpdateInGroup(typeof(UnityEngine.Experimental.PlayerLoop.PostLateUpdate))]
  public class CameraTrackingSystem : ComponentSystem {
    ComponentGroup camera;
    ComponentGroup player;

    protected override void OnCreateManager () {
      camera = GetComponentGroup (
        typeof (MainCamera),
        typeof (Transform),
        typeof (CameraLerpTime),
        typeof (CameraLeadDirection),
        typeof (CameraLeadDistance)
      );

      player = GetComponentGroup (
        typeof (Player),
        typeof (Transform)
      );

      RequireForUpdate (camera);
      RequireForUpdate (player);
    }

    protected override void OnUpdate () {
      var c_entity = camera.GetEntityArray ();
      var c_transform = camera.GetComponentArray<Transform> ();
      var c_lerpTime = camera.GetComponentDataArray<CameraLerpTime> ();
      var c_direction = camera.GetComponentDataArray<CameraLeadDirection> ();
      var c_distance = camera.GetComponentDataArray<CameraLeadDistance> ();

      var p_entity = player.GetEntityArray ();
      var p_transform = player.GetComponentArray<Transform> ();

      for (int i = 0; i < camera.CalculateLength (); i++) {
        c_transform[i].position = Vector3.Lerp (
          c_transform[i].position,
          new Vector3 (
            p_transform[i].position.x + (
              c_distance[i].Value * c_direction[i].Value
            ),
            p_transform[i].position.y,
            c_transform[i].position.z
          ),
          Time.fixedDeltaTime * c_lerpTime[i].Value
        );
      }
    }
  }
}