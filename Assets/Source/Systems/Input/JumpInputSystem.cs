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
        typeof(JumpReady)
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
        PostUpdateCommands.RemoveComponent<JumpReady>(p_entity[i]);
        PostUpdateCommands.AddComponent<JumpStart>(p_entity[i], new JumpStart { });

        /* ----------------- DEVELOPER SETTINGS - REMOVE ME -------------------- */
        if (Bootstrap.DeveloperSettings.DebugJumpState) {
          Debug.Log($"<color=green>{this.GetType()}</color> JumpStart");
        }
        /* ----------------- DEVELOPER SETTINGS - REMOVE ME -------------------- */
      }
    }
  }
}