using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace RocketJump {
  [UpdateInGroup(typeof(CleanupGroup))]
  public class RocketKeyDownCleanupSystem : ComponentSystem {
    ComponentGroup rocket;

    protected override void OnCreateManager () {
      rocket = GetComponentGroup(
        typeof(RocketKeyDown)
      );
    }

    protected override void OnUpdate () {
      var bk_entity = rocket.GetEntityArray();

      for (var i = 0; i < rocket.CalculateLength(); i++) {
        PostUpdateCommands.RemoveComponent<RocketKeyDown>(bk_entity[i]);
      }
    }
  }
}