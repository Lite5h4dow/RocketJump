using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump {
  public class BoostCooldownSystem : ComponentSystem {
    ComponentGroup boost;

    protected override void OnCreateManager () {
      boost = GetComponentGroup (
        typeof (Player),
        typeof (BoostEnd)
      );
    }

    protected override void OnUpdate () {
      var b_entities = boost.GetEntityArray();
      var b_cooldown = boost.GetComponentDataArray<BoostEnd>();

      for (int i = 0; i < boost.CalculateLength (); i++) {
        if(b_cooldown[i].Value > 0)
          continue;

        PostUpdateCommands.RemoveComponent<BoostEnd>(b_entities[i]);
        PostUpdateCommands.AddComponent<BoostReady>(
          b_entities[i],
          new BoostReady{}
        );
       }
    }
  }
}