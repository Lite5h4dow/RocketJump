using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump {
  [UpdateInGroup(typeof(InputGroup))]
  public class BoostInputSystem : ComponentSystem {
    ComponentGroup player;
    ComponentGroup input;

    protected override void OnCreateManager () {
      player = GetComponentGroup(
        typeof(Player),
        typeof(BoostReady)
      );
      input = GetComponentGroup(
        typeof(BoostKeyDown)
      );

      RequireForUpdate(player);
      RequireForUpdate(input);
    }

    protected override void OnUpdate () {
      var p_entity = player.GetEntityArray();

      for (int i = 0; i < player.CalculateLength(); i++) {
        PostUpdateCommands.RemoveComponent<BoostReady>(p_entity[i]);
        PostUpdateCommands.AddComponent<BoostStart>(p_entity[i], new BoostStart { });

        /* ----------------- DEVELOPER SETTINGS - REMOVE ME -------------------- */
        if (Bootstrap.DeveloperSettings.DebugBoostState) {
          Debug.Log($"<color=green>{this.GetType()}</color> BoostStart");
        }
        /* ----------------- DEVELOPER SETTINGS - REMOVE ME -------------------- */
      }
    }
  }
}