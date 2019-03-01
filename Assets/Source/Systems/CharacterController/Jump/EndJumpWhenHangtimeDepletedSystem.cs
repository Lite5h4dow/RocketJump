using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump {
  public class EndJumpWhenHangtimeDepletedSystem : ComponentSystem {
    ComponentGroup jump;

    protected override void OnCreateManager () {
      jump = GetComponentGroup(
        typeof(Player),
        typeof(Jumping)
      );
    }

    protected override void OnUpdate () {
      var j_entities = jump.GetEntityArray();
      var j_jumping = jump.GetComponentDataArray<Jumping>();

      for (int i = 0; i < jump.CalculateLength(); i++) {
        if (j_jumping[i].Hangtime > 0)
          continue;

        PostUpdateCommands.RemoveComponent<Jumping>(j_entities[i]);
        PostUpdateCommands.AddComponent<EndJump>(j_entities[i], new EndJump { });

        /* ----------------- DEVELOPER SETTINGS - REMOVE ME -------------------- */
        if (Bootstrap.DeveloperSettings.DebugJumpState) {
          Debug.Log($"<color=green>{this.GetType()}</color> EndJump");
        }
        /* ----------------- DEVELOPER SETTINGS - REMOVE ME -------------------- */
      }
    }
  }
}