using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump {
  [UpdateAfter (typeof (JumpInputSystem))]
  public class JumpDecrementSystem : ComponentSystem {
    ComponentGroup timer;

    protected override void OnCreateManager () {
      timer = GetComponentGroup (
        typeof (Player),
        typeof (Jumping)
      );
    }

    protected override void OnUpdate () {
      var t_entity = timer.GetEntityArray ();
      var t_jumping = timer.GetComponentDataArray<Jumping> ();
     

      for (int i = 0; i < timer.CalculateLength (); i++) {
        EntityManager.SetComponentData<Jumping> (t_entity[i], new Jumping {
          Value = t_jumping[i].Value - Time.deltaTime
        });
      }
    }
  }
}