using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump {
  [UpdateInGroup(typeof(CleanupGroup))]
  public class CollidedWithGroundCleanupSystem : ComponentSystem {
    ComponentGroup impact;

    protected override void OnCreateManager () {
      impact = GetComponentGroup(
        typeof(CollidedWithGround)
      );
    }

    protected override void OnUpdate () {
      var i_entity = impact.GetEntityArray();

      for (var i = 0; i < impact.CalculateLength(); i++) {
        PostUpdateCommands.RemoveComponent<CollidedWithGround>(i_entity[i]);
      }
    }
  }
}