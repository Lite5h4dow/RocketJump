using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump {
  public class DecrementJumpHangtimeSystem : ComponentSystem {
    ComponentGroup jump;

    protected override void OnCreateManager () {
      jump = GetComponentGroup(
        typeof(Player),
        typeof(Jumping)
      );
    }

    protected override void OnUpdate () {
      var j_entities = jump.GetEntityArray();
      var j_jumping = jump.GetComponentDataArray<Jumping>();

      var dt = Time.deltaTime;
      for (int i = 0; i < jump.CalculateLength(); i++) {
        EntityManager.SetComponentData<Jumping>(j_entities[i], new Jumping {
          Hangtime = j_jumping[i].Hangtime - dt
        });
      }
    }
  }
}