using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump{
  public class DoJumpSystem:ComponentSystem{
    ComponentGroup jump;

    protected override void OnCreateManager(){
      jump = GetComponentGroup(
        ComponentType.Subtractive(typeof(JumpTimer)),
        typeof(Player),
        typeof(JumpVelocity),
        typeof(JumpCooldown),
        typeof(JumpStart),
        typeof(Rigidbody2D)
      );
    }

    protected override void OnUpdate(){
      var j_entities = jump.GetEntityArray();
      var j_velocity = jump.GetComponentDataArray<JumpVelocity>();
      var j_cooldown = jump.GetComponentDataArray<JumpCooldown>();
      var j_rigidbody2D = jump.GetComponentArray<Rigidbody2D>();

      for(int i = 0; i < jump.CalculateLength(); i++){
        j_rigidbody2D[i].velocity += new Vector2(0,j_velocity[i].Value);
        PostUpdateCommands.RemoveComponent<JumpStart>(j_entities[i]);
        PostUpdateCommands.AddComponent<JumpTimer>(j_entities[i], new JumpTimer{Value = j_cooldown[i].Value});
        
      }
    }
  }
}