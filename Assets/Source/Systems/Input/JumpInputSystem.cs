using UnityEngine;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace RocketJump {
  public class JumpInputSystem : ComponentSystem {
    ComponentGroup player;
    ComponentGroup jumpKey;

    protected override void OnCreateManager () {
      player = GetComponentGroup(
        typeof(Player),
        typeof(ReadyToJump)
      );
      jumpKey = GetComponentGroup(
        typeof(JumpKeyDown)
      );

      RequireForUpdate(player);
      RequireForUpdate(jumpKey);
    }

    protected override void OnUpdate () {
      var p_entity = player.GetEntityArray();

      for (int i = 0; i < player.CalculateLength(); i++) {
        PostUpdateCommands.AddComponent<DoJump>(p_entity[i], new DoJump { });
      }
    }
  }
}