using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump {
  public class GroundedSystem : ComponentSystem {
    ComponentGroup grounded;

    protected override void OnCreateManager () {
      grounded = GetComponentGroup(
        ComponentType.Subtractive(typeof(Grounded)),
        typeof(Player),
        typeof(CollidedWithGround)
      );
    }

    protected override void OnUpdate () {
      var g_player = grounded.GetEntityArray();
      var g_collision = grounded.GetComponentDataArray<CollidedWithGround>();

      for (int i = 0; i < grounded.CalculateLength(); i++) {
        PostUpdateCommands.AddComponent<Grounded>(g_player[i], new Grounded { });

        // Damage Example:
        // EntityManager.GetComponentData<Damage>(g_collision[i].Impact.OtherEntity);
      }
    }
  }
}