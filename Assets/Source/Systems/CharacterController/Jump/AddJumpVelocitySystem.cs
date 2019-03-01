using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump {
  public class AddJumpVelocitySystem : ComponentSystem {
    ComponentGroup jump;

    protected override void OnCreateManager () {
      jump = GetComponentGroup(
        typeof(Player),
        typeof(JumpVelocity),
        typeof(Jumping),
        typeof(Rigidbody2D)
      );
    }

    protected override void OnUpdate () {
      var j_entities = jump.GetEntityArray();
      var j_jumpVelocity = jump.GetComponentDataArray<JumpVelocity>();
      var j_rigidbody = jump.GetComponentArray<Rigidbody2D>();

      for (int i = 0; i < jump.CalculateLength(); i++) {
        j_rigidbody[i].velocity = new Vector2(j_rigidbody[i].velocity.x, j_jumpVelocity[i].Value);
      }
    }
  }
}