using UnityEngine;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace RocketJump {
  public class ReadyToJumpSystem : ComponentSystem {
    ComponentGroup player;

    protected override void OnCreateManager () {
      player = GetComponentGroup(
        typeof(DoneJump)
      );
    }

    protected override void OnUpdate () {
      var p_entity = player.GetEntityArray();

      for (int i = 0; i < player.CalculateLength(); i++) {
        // TODO: check if grounded

        PostUpdateCommands.RemoveComponent<DoneJump>(p_entity[i]);
        PostUpdateCommands.AddComponent<ReadyToJump>(p_entity[i], new ReadyToJump { });

        /* ----------------- DEVELOPER SETTINGS - REMOVE ME -------------------- */
        if (Bootstrap.DeveloperSettings.DebugJumpState) {
          Debug.Log($"<color=green>{this.GetType()}</color> ReadyToJump");
        }
        /* ----------------- DEVELOPER SETTINGS - REMOVE ME -------------------- */
      }
    }
  }
}