using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump {
  [UpdateAfter (typeof (BoostInputSystem))]
  public class DecrementBoostSystem : ComponentSystem {
    ComponentGroup boost;

    protected override void OnCreateManager () {
      boost = GetComponentGroup (
        typeof (Player),
        typeof (Boosting)
      );
    }

    protected override void OnUpdate () {
      var b_entity = boost.GetEntityArray ();
      var b_boosting = boost.GetComponentDataArray<Boosting> ();

      for (int i = 0; i < boost.CalculateLength (); i++) {
        // NOTE: break these so that lines aren't longer than 100 characters, easier to grok when it's broken up
        EntityManager.SetComponentData (b_entity[i], new Boosting {
          Value = b_boosting[i].Value - Time.deltaTime
        });
      }
    }
  }
}