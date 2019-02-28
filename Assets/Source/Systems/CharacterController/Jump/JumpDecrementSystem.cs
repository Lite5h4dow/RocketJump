using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump {
  public class JumpDecrementSystem : ComponentSystem {
    ComponentGroup jump;

    protected override void OnCreateManager () {
      jump = GetComponentGroup (
        typeof (Player),
        typeof (JumpTimer)
      );
    }

    protected override void OnUpdate () {
      var j_entities = jump.GetEntityArray ();
      var j_jumpTimer = jump.GetComponentDataArray<JumpTimer> ();

      for (int i = 0; i < jump.CalculateLength (); i++) {

        EntityManager.SetComponentData<JumpTimer> (j_entities[i], new JumpTimer {
          Value = (j_jumpTimer[i].Value - Time.deltaTime)
        });
      }
    }
  }
}