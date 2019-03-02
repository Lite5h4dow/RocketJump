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
        typeof (JumpTimer)
      );

      key = GetComponentGroup (
        typeof (JumpKeyDown)
      );

      RequireForUpdate (jump);
      RequireForUpdate (key);
    }

    protected override void OnUpdate () {
      var j_entities = jump.GetEntityArray ();
      var j_timer = jump.GetComponentDataArray<JumpTimer> ();

      for (int i = 0; i < jump.CalculateLength (); i++) {
        Debug.Log("test");
        PostUpdateCommands.AddComponent<Jumping> (j_entities[i], new Jumping {
          JumpTime = j_timer[i].Value
        });
        PostUpdateCommands.RemoveComponent<JumpReady>(j_entities[i]);
      }
    }
  }
}