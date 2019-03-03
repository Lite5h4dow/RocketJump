using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump {
  public class CameraLeadLeftSystem : ComponentSystem {
    ComponentGroup camera;
    ComponentGroup player;

    protected override void OnCreateManager () {
      camera = GetComponentGroup (
        typeof (MainCamera),
        typeof (CameraLeadDirection)
      );

      player = GetComponentGroup (
        typeof (Player),
        typeof (Rigidbody2D)
      );
      RequireForUpdate (camera);
      RequireForUpdate (player);
    }

    protected override void OnUpdate () {
      var c_entity = camera.GetEntityArray ();
      var c_direction = camera.GetComponentDataArray<CameraLeadDirection> ();

      var p_entity = player.GetEntityArray ();
      var p_rigidbody = player.GetComponentArray<Rigidbody2D> ();

      for (int i = 0; i < camera.CalculateLength (); i++) {
        if (p_rigidbody[i].velocity.x <= 0)
          continue;

        EntityManager.SetComponentData<CameraLeadDirection> (
          c_entity[i], new CameraLeadDirection { Value = 1 }
        );
      }
    }
  }
}