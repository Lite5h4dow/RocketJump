using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump {
  public class FuelChargeSystem : ComponentSystem {
    ComponentGroup charge;

    protected override void OnCreateManager () {
      charge = GetComponentGroup (
        typeof (MaxRocketFuel),
        typeof (RocketInactive),
        typeof (Grounded)
      );
    }

    protected override void OnUpdate () {
      var c_entity = charge.GetEntityArray ();
      var c_fuel = charge.GetComponentDataArray<RocketInactive> ();
      var c_maxFuel = charge.GetComponentDataArray<MaxRocketFuel>();

      for (int i = 0; i < charge.CalculateLength (); i++) {
        if(c_fuel[i].Value >= c_maxFuel[i].Value)
          continue;

        EntityManager.SetComponentData<RocketInactive> (c_entity[i], new RocketInactive {
          Value = c_fuel[i].Value + Time.deltaTime
        });
      }
    }
  }
}