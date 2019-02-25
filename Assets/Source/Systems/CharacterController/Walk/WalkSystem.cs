using UnityEngine;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace RocketJump {
  public class WalkSystem : ComponentSystem {
    ComponentGroup player;

    protected override void OnCreateManager () {
      player = GetComponentGroup(
        typeof(Player),
        typeof(Transform),
        typeof(MovementInput),
        typeof(WalkSpeed)
      );
    }

    protected override void OnUpdate () {
      var p_entity = player.GetEntityArray();
      var p_movementInput = player.GetComponentDataArray<MovementInput>();
      var p_walkSpeed = player.GetComponentDataArray<WalkSpeed>();
      var p_transform = player.GetComponentArray<Transform>();

      var dt = Time.deltaTime;
      for (int i = 0; i < player.CalculateLength(); i++) {
        if (p_movementInput[i].Value.Equals(Vector2.zero))
          continue;

        p_transform[i].position = Vector3.Lerp(
          p_transform[i].position,
          p_transform[i].position + new Vector3(p_movementInput[i].Value.x, p_movementInput[i].Value.y, 0),
          p_walkSpeed[i].Value * dt
        );
      }
    }
  }
}