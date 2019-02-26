using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace RocketJump {
  [UpdateInGroup(typeof(CleanupGroup))]
  public class BoostKeyDownCleanupSystem : ComponentSystem {
    ComponentGroup boostKey;

    protected override void OnCreateManager () {
      boostKey = GetComponentGroup(
        typeof(BoostKeyDown)
      );
    }

    protected override void OnUpdate () {
      var bk_entity = boostKey.GetEntityArray();

      for (var i = 0; i < boostKey.CalculateLength(); i++) {
        PostUpdateCommands.RemoveComponent<BoostKeyDown>(bk_entity[i]);
      }
    }
  }
}