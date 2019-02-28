using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump {
  [UpdateBefore (typeof (JumpDecrementSystem))]
  public class JumpCountdownSystem : ComponentSystem {
    ComponentGroup jump;

    protected override void OnCreateManager () {
      jump = GetComponentGroup (
        typeof (Player),
        typeof (JumpTimer)
      );
    }

    protected override void OnUpdate () {
      var j_entities = jump.GetEntityArray ();
      var j_timer = jump.GetComponentDataArray<JumpTimer> ();

      for (int i = 0; i < jump.CalculateLength (); i++) {
        if (j_timer[i].Value < 0)
          continue;

        PostUpdateCommands.RemoveComponent<JumpTimer> (j_entities[i]);
      }
    }
  }
}