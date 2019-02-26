using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace RocketJump {
  [UpdateInGroup(typeof(CleanupGroup))]
  public class BoostKeyUpCleanupSystem : ComponentSystem {
    ComponentGroup boostKey;

    protected override void OnCreateManager () {
      boostKey = GetComponentGroup(
        typeof(BoostKeyUp)
      );
    }

    protected override void OnUpdate () {
      var bk_entity = boostKey.GetEntityArray();

      for (var i = 0; i < boostKey.CalculateLength(); i++) {
        PostUpdateCommands.RemoveComponent<BoostKeyUp>(bk_entity[i]);
      }
    }
  }
}