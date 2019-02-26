using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump {
  public class BoostSetupSystem : ComponentSystem {
    ComponentGroup boost;
    float timerLength = 10;
    protected override void OnCreateManager () {
      boost = GetComponentGroup(
        typeof(BoostStart),
        typeof(BoostReady)
      );

      // NOTE: not needed for single component group
      RequireForUpdate(boost);
    }

    protected override void OnUpdate () {
      var b_entity = boost.GetEntityArray();
      var b_timer = boost.GetComponentDataArray<BoostReady>();

      for (int i = 0; i < boost.CalculateLength(); i++) {
        PostUpdateCommands.RemoveComponent<BoostStart>(b_entity[i]);
        EntityManager.SetComponentData(b_entity[i], new BoostReady { Value = timerLength });
      }
    }
  }
}