using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump {
  public class ReadyToJumpWhenGroundedSystem : ComponentSystem {
    ComponentGroup jump;

    protected override void OnCreateManager () {
      jump = GetComponentGroup(
        typeof(Player),
        typeof(Grounded),
        typeof(EndJump)
      );
    }

    protected override void OnUpdate () {
      var j_entities = jump.GetEntityArray();

      for (int i = 0; i < jump.CalculateLength(); i++) {
        PostUpdateCommands.RemoveComponent<EndJump>(j_entities[i]);
        PostUpdateCommands.AddComponent<ReadyToJump>(j_entities[i], new ReadyToJump { });

        /* ----------------- DEVELOPER SETTINGS - REMOVE ME -------------------- */
        if (Bootstrap.DeveloperSettings.DebugJumpState) {
          Debug.Log($"<color=green>{this.GetType()}</color> ReadyToJump");
        }
        /* ----------------- DEVELOPER SETTINGS - REMOVE ME -------------------- */
      }
    }
  }
}