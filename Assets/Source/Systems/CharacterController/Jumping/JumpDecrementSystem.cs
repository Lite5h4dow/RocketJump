using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump {
  [UpdateAfter (typeof (InputGroup))]
  public class JumpDecrementSystem : ComponentSystem {
    ComponentGroup timer;

    protected override void OnCreateManager () {
      timer = GetComponentGroup (
        typeof (JumpVelocity),
        typeof (Jumping),
        typeof (Rigidbody2D)
      );
    }

    protected override void OnUpdate () {
      var t_entities = timer.GetEntityArray ();
      var t_jumping = timer.GetComponentDataArray<Jumping> ();
      var t_velocity = timer.GetComponentDataArray<JumpVelocity> ();
      var t_rigidbody = timer.GetComponentArray<Rigidbody2D> ();

      for (int i = 0; i < timer.CalculateLength (); i++) {
        EntityManager.SetComponentData<Jumping> (t_entities[i], new Jumping {
          JumpTime = t_jumping[i].JumpTime - Time.deltaTime
        });

        t_rigidbody[i].velocity = new Vector2 (
          t_rigidbody[i].velocity.x,
          t_velocity[i].Velocity
        );
      }
    }
  }
}