using UnityEngine;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace RocketJump {
  public class EndJumpWhenHangtimeDepletedSystem : ComponentSystem {
    ComponentGroup player;

    protected override void OnCreateManager () {
      player = GetComponentGroup(
        typeof(Jumping)
      );
    }

    protected override void OnUpdate () {
      var p_entity = player.GetEntityArray();
      var p_jumping = player.GetComponentDataArray<Jumping>();

      for (int i = 0; i < player.CalculateLength(); i++) {
        if (p_jumping[i].Hangtime > 0)
          continue;

        PostUpdateCommands.RemoveComponent<Jumping>(p_entity[i]);
        PostUpdateCommands.AddComponent<ReadyToJump>(p_entity[i], new ReadyToJump { });
      }
    }
  }
}