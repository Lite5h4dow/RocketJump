using UnityEngine;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace RocketJump {
  public class CoutndownJumpHangtimeSystem : ComponentSystem {
    ComponentGroup jumper;

    protected override void OnCreateManager () {
      jumper = GetComponentGroup(
        typeof(Jumping)
      );
    }

    protected override void OnUpdate () {
      var j_entity = jumper.GetEntityArray();
      var j_Jumping = jumper.GetComponentDataArray<Jumping>();

      var dt = Time.deltaTime;
      for (int i = 0; i < jumper.CalculateLength(); i++) {
        EntityManager.SetComponentData<Jumping>(j_entity[i], new Jumping {
          Hangtime = j_Jumping[i].Hangtime - dt
        });
      }
    }
  }
}