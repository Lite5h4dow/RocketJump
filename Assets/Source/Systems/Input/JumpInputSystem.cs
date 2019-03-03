using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump {
  public class JumpInputSystem : ComponentSystem {
    ComponentGroup jump;
    ComponentGroup key;

    protected override void OnCreateManager () {
      jump = GetComponentGroup (
        typeof (Player),
        typeof (JumpReady),
        typeof (JumpAccelerationTimer)
      );

      key = GetComponentGroup (
        typeof (JumpKeyDown)
      );

      RequireForUpdate (jump);
      RequireForUpdate (key);
    }

    protected override void OnUpdate () {
      var j_entity = jump.GetEntityArray ();
      var j_timer = jump.GetComponentDataArray<JumpAccelerationTimer> ();

      for (int i = 0; i < jump.CalculateLength (); i++) {
        PostUpdateCommands.RemoveComponent<JumpReady>(j_entity[i]);
        PostUpdateCommands.AddComponent<Jumping> (j_entity[i], new Jumping {
          Value = j_timer[i].Value
        });
      }
    }
  }
}