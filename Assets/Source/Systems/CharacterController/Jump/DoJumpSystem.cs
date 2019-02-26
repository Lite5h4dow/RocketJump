using UnityEngine;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace RocketJump {
  public class DoJumpSystem : ComponentSystem {
    ComponentGroup player;

    protected override void OnCreateManager () {
      player = GetComponentGroup(
        typeof(DoJump),
        typeof(MaxJumpHangtime)
      );
    }

    protected override void OnUpdate () {
      var p_entity = player.GetEntityArray();
      var p_maxJumpHangtime = player.GetComponentDataArray<MaxJumpHangtime>();

      var dt = Time.deltaTime;
      for (int i = 0; i < player.CalculateLength(); i++) {
        // TODO: this system should only transition to jumping if all conditions are met such as "if(player is on ground)"

        PostUpdateCommands.RemoveComponent<DoJump>(p_entity[i]);
        PostUpdateCommands.AddComponent<Jumping>(p_entity[i], new Jumping {
          Hangtime = p_maxJumpHangtime[i].Value
        });

        /* ----------------- DEVELOPER SETTINGS - REMOVE ME -------------------- */
        if (Bootstrap.DeveloperSettings.DebugJumpState) {
          Debug.Log($"<color=green>{this.GetType()}</color> Jumping");
        }
        /* ----------------- DEVELOPER SETTINGS - REMOVE ME -------------------- */
      }
    }
  }
}