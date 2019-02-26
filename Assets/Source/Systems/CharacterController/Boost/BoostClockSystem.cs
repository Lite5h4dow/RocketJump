using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump {
  [UpdateAfter (typeof (BoostInputSystem))]
  public class BoostClockSystem : ComponentSystem {
    ComponentGroup boost;

    protected override void OnCreateManager () {
      boost = GetComponentGroup (
        typeof (Player),
        typeof (Boosting),
        typeof (BoostCooldown)
      );
    }

    protected override void OnUpdate () {
      var b_entity = boost.GetEntityArray ();
      var b_timer = boost.GetComponentDataArray<Boosting> ();
      var b_cooldown = boost.GetComponentDataArray<BoostCooldown> ();

      for (int i = 0; i < boost.CalculateLength (); i++) {
        if (b_timer[i].Value > 0) {
          EntityManager.SetComponentData (b_entity[i], new Boosting { Value = b_timer[i].Value - Time.deltaTime });
          continue;
        }
        
        PostUpdateCommands.RemoveComponent<Boosting> (b_entity[i]);
        PostUpdateCommands.AddComponent<BoostEnd> (b_entity[i], new BoostEnd { Value = b_cooldown[i].Value });
      }
    }
  }
}