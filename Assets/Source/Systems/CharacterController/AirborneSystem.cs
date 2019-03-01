using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump {
  public class AirborneSystem : ComponentSystem {
    ComponentGroup airborne;

    protected override void OnCreateManager () {
      airborne = GetComponentGroup(
        typeof(CollidedWithGround),
        typeof(Grounded),
        typeof(Player)
      );
    }

    protected override void OnUpdate () {
      var a_player = airborne.GetEntityArray();
      var a_collided = airborne.GetComponentDataArray<CollidedWithGround>();

      for (int i = 0; i < airborne.CalculateLength(); i++) {
        if (a_collided[i].Impact.State != State.Overlap.Exit)
          continue;

        PostUpdateCommands.RemoveComponent<Grounded>(a_player[i]);
      }
    }
  }
}