using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace RocketJump {
  [UpdateInGroup(typeof(CleanupGroup))]
  public class JumpKeyDownCleanupSystem : ComponentSystem {
    ComponentGroup jumpKey;

    protected override void OnCreateManager () {
      jumpKey = GetComponentGroup(
        typeof(JumpKeyDown)
      );
    }

    protected override void OnUpdate () {
      var jk_entity = jumpKey.GetEntityArray();

      for (var i = 0; i < jumpKey.CalculateLength(); i++) {
        PostUpdateCommands.RemoveComponent<JumpKeyDown>(jk_entity[i]);
      }
    }
  }
}