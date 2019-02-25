using UnityEngine;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace RocketJump {
  public class JumpingSystem : ComponentSystem {
    ComponentGroup player;

    protected override void OnCreateManager () {
      player = GetComponentGroup(
        typeof(Jumping),
        typeof(JumpSpeed),
        typeof(Position)
      );
    }

    protected override void OnUpdate () {
      var p_entity = player.GetEntityArray();
      var p_position = player.GetComponentDataArray<Position>();
      var p_jumpSpeed = player.GetComponentDataArray<JumpSpeed>();

      var dt = Time.deltaTime;
      for (int i = 0; i < player.CalculateLength(); i++) {
        EntityManager.SetComponentData<Position>(p_entity[i], new Position {
          Value = new float3(p_position[i].Value.x, p_position[i].Value.y * dt * p_jumpSpeed[i].Value, p_position[i].Value.z)
        });
      }
    }
  }
}