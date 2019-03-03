using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump {
  [UpdateAfter(typeof(RocketFuelEndSystem))]
  public class RocketThrustSystem : ComponentSystem {
    ComponentGroup thrust;

    protected override void OnCreateManager () {
      thrust = GetComponentGroup (
        typeof (Player),
        typeof (RocketActive),
        typeof (RocketVelocity),
        typeof (Rigidbody2D)
      );
    }

    protected override void OnUpdate () {
      var t_entity = thrust.GetEntityArray ();
      var t_thrust = thrust.GetComponentDataArray<RocketVelocity> ();
      var t_rigidbody = thrust.GetComponentArray<Rigidbody2D> ();

      for (int i = 0; i < thrust.CalculateLength (); i++) {
        t_rigidbody[i].velocity = new float2 (
          t_rigidbody[i].velocity.x,
          t_thrust[i].Value
        );
      }
    }
  }
}