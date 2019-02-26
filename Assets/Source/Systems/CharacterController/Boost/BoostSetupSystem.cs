using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump {
  [UpdateAfter(typeof(BoostInputSystem))]
  public class BoostSetupSystem : ComponentSystem {
    ComponentGroup boost;
    protected override void OnCreateManager () {
      boost = GetComponentGroup(
        typeof(Player),
        typeof(BoostStart),
        typeof(MaxBoost),
        // NOTE: you don't use these so get rid of them
        typeof(WalkSpeed),
        typeof(BaseWalkSpeed)
      );
    }

    protected override void OnUpdate () {
      var b_entity = boost.GetEntityArray();
      var b_maxBoost = boost.GetComponentDataArray<MaxBoost>();

      for (int i = 0; i < boost.CalculateLength(); i++) {
        PostUpdateCommands.RemoveComponent<BoostStart>(b_entity[i]);
        PostUpdateCommands.AddComponent<Boosting>(b_entity[i], new Boosting { Value = b_maxBoost[i].Value });

        /* ----------------- DEVELOPER SETTINGS - REMOVE ME -------------------- */
        if (Bootstrap.DeveloperSettings.DebugBoostState) {
          Debug.Log($"<color=green>{this.GetType()}</color> Boosting");
        }
        /* ----------------- DEVELOPER SETTINGS - REMOVE ME -------------------- */
      }
    }
  }
}