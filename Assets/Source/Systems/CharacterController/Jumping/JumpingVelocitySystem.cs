using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump{
  [UpdateAfter(typeof(JumpDecrementSystem))]
  public class JumpingVelocitySystem:ComponentSystem{
    ComponentGroup jump;

    protected override void OnCreateManager(){
      jump = GetComponentGroup(
        typeof(Player),
        typeof(Jumping),
        typeof(JumpVelocity),
        typeof(Rigidbody2D)
      );
    }

    protected override void OnUpdate(){
      var j_entity = jump.GetEntityArray();
      var j_velocity = jump.GetComponentDataArray<JumpVelocity>();
      var j_rigidbody = jump.GetComponentArray<Rigidbody2D>();
      
      for(int i = 0; i < jump.CalculateLength(); i++){
        j_rigidbody[i].velocity = new Vector2 (
          j_rigidbody[i].velocity.x,
          j_velocity[i].Value
        );
      }
    }
  }
}