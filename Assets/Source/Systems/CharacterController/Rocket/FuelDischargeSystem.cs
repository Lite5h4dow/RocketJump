using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump {
  [UpdateAfter(typeof(RocketFuelEndSystem))]
  public class FuelDischargeSystem : ComponentSystem {
    ComponentGroup discharge;

    protected override void OnCreateManager () {
      discharge = GetComponentGroup (
        typeof (RocketActive)
      );
    }

    protected override void OnUpdate () {
      var d_entity = discharge.GetEntityArray ();
      var d_fuel = discharge.GetComponentDataArray<RocketActive> ();

      for (int i = 0; i < discharge.CalculateLength (); i++) {
        EntityManager.SetComponentData (d_entity[i], new RocketActive {
          Value = d_fuel[i].Value - Time.deltaTime
        });
      }
    }
  }
}