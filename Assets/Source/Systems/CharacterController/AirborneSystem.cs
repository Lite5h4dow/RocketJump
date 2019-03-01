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
        ComponentType.Subtractive(typeof(CollidedWithGround)),
        typeof(Grounded),
        typeof(Player)
      );
    }

    protected override void OnUpdate () {
      var a_player = airborne.GetEntityArray();

      for (int i = 0; i < airborne.CalculateLength(); i++) {
        PostUpdateCommands.RemoveComponent<Grounded>(a_player[i]);
        Debug.Log("airborne");
      }
    }
  }
}