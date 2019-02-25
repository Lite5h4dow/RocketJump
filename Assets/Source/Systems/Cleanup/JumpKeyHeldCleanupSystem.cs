using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace RocketJump {
  [UpdateInGroup(typeof(CleanupGroup))]
  public class JumpKeyHeldCleanupSystem : ComponentSystem {
    ComponentGroup jumpKey;

    protected override void OnCreateManager () {
      jumpKey = GetComponentGroup(
        typeof(JumpKeyHeld)
      );
    }

    protected override void OnUpdate () {
      var jk_entity = jumpKey.GetEntityArray();

      for (var i = 0; i < jumpKey.CalculateLength(); i++) {
        PostUpdateCommands.RemoveComponent<JumpKeyHeld>(jk_entity[i]);
      }
    }
  }
}