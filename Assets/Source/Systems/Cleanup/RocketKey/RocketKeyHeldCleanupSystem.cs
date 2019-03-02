using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace RocketJump {
  [UpdateInGroup(typeof(CleanupGroup))]
  public class RocketKeyHeldCleanupSystem : ComponentSystem {
    ComponentGroup rocketKey;

    protected override void OnCreateManager () {
      rocketKey = GetComponentGroup(
        typeof(RocketKeyHeld)
      );
    }

    protected override void OnUpdate () {
      var bk_entity = rocketKey.GetEntityArray();

      for (var i = 0; i < rocketKey.CalculateLength(); i++) {
        PostUpdateCommands.RemoveComponent<RocketKeyHeld>(bk_entity[i]);
      }
    }
  }
}