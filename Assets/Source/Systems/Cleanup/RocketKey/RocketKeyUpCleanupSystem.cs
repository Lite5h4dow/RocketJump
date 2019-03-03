using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace RocketJump {
  [UpdateInGroup(typeof(CleanupGroup))]
  public class RocketKeyUpCleanupSystem : ComponentSystem {
    ComponentGroup rocketKey;

    protected override void OnCreateManager () {
      rocketKey = GetComponentGroup(
        typeof(RocketKeyUp)
      );
    }

    protected override void OnUpdate () {
      var bk_entity = rocketKey.GetEntityArray();

      for (var i = 0; i < rocketKey.CalculateLength(); i++) {
        PostUpdateCommands.RemoveComponent<RocketKeyUp>(bk_entity[i]);
      }
    }
  }
}