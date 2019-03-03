using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump{
  [UpdateAfter(typeof(JumpingVelocitySystem))]
  public class JumpingSystem:ComponentSystem{
    ComponentGroup jump;

    protected override void OnCreateManager(){
      jump = GetComponentGroup(
        typeof(Jumping),
        typeof(Player)
      );
    }

    protected override void OnUpdate(){
      var j_entity = jump.GetEntityArray();
      var j_timer = jump.GetComponentDataArray<Jumping>();
      
      for(int i = 0; i < jump.CalculateLength(); i++){
        if(j_timer[i].Value > 0)
          continue;

        

        PostUpdateCommands.RemoveComponent<Jumping>(j_entity[i]);
        PostUpdateCommands.AddComponent<JumpEnd>(j_entity[i], new JumpEnd{});
      }
    }
  }
}