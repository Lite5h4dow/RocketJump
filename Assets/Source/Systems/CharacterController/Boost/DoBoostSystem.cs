using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump {
  public class DoBoostSystem : ComponentSystem {
    ComponentGroup boost;

    protected override void OnCreateManager () {
      boost = GetComponentGroup (
        typeof (Player),
        typeof (Boosting),
        typeof (WalkSpeed),
        typeof (BoostSpeed)
      );
    }

    protected override void OnUpdate () {
      var b_entities = boost.GetEntityArray ();
      var b_walkSpeed = boost.GetComponentDataArray<WalkSpeed> ();
      var b_boostSpeed = boost.GetComponentDataArray<BoostSpeed> ();

      for (int i = 0; i < boost.CalculateLength (); i++) {
        EntityManager.SetComponentData (b_entities[i], new WalkSpeed {
          Value = b_boostSpeed[i].Value
          
        });
      }
    }
  }
}