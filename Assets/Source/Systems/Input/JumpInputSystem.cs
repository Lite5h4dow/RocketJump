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
        typeof(Grounded),
        typeof(Player),
        typeof(JumpHangtime),
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
      var p_jumpHangtime = player.GetComponentDataArray<JumpHangtime>();

      for (int i = 0; i < player.CalculateLength(); i++) {
        PostUpdateCommands.RemoveComponent<ReadyToJump>(p_entity[i]);
        PostUpdateCommands.AddComponent<Jumping>(p_entity[i], new Jumping {
          Hangtime = p_jumpHangtime[i].Value
        });

        /* ----------------- DEVELOPER SETTINGS - REMOVE ME -------------------- */
        if (Bootstrap.DeveloperSettings.DebugJumpState) {
          Debug.Log($"<color=green>{this.GetType()}</color> JumpStart");
        }
        /* ----------------- DEVELOPER SETTINGS - REMOVE ME -------------------- */
      }
    }
  }
}