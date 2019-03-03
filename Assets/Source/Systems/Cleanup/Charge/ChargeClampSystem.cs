using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump {
  public class ChargeClampSystem : ComponentSystem {
    ComponentGroup clamp;

    protected override void OnCreateManager () {
      clamp = GetComponentGroup (
        typeof (Player),
        typeof (MaxRocketFuel),
        typeof (RocketInactive),
        typeof (Grounded)
      );
    }

    protected override void OnUpdate () {
      var c_entity = clamp.GetEntityArray ();
      var c_charge = clamp.GetComponentDataArray<RocketInactive> ();
      var c_maxCharge = clamp.GetComponentDataArray<MaxRocketFuel> ();

      for (int i = 0; i < clamp.CalculateLength (); i++) {
        if (c_charge[i].Value <= c_maxCharge[i].Value)
          continue;

        EntityManager.SetComponentData<RocketInactive> (c_entity[i], new RocketInactive {
          Value = Mathf.Clamp (
            c_charge[i].Value,
            0,
            c_maxCharge[i].Value
          )
        });
      }
    }
  }
}