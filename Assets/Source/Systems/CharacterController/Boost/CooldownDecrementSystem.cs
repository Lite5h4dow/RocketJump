using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump {
  [UpdateBefore (typeof (BoostCooldownSystem))]
  public class CooldownDecrementSystem : ComponentSystem {
    ComponentGroup boost;

    protected override void OnCreateManager () {
      boost = GetComponentGroup (
        typeof (Player),
        typeof (BoostEnd)
      );
    }

    protected override void OnUpdate () {
      var b_entities = boost.GetEntityArray ();
      var b_cooldown = boost.GetComponentDataArray<BoostEnd> ();

      for (int i = 0; i < boost.CalculateLength (); i++) {
        EntityManager.SetComponentData (b_entities[i], new BoostEnd {
          Value = b_cooldown[i].Value - Time.deltaTime
        });
      }
    }
  }
}