using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump{
  [UpdateAfter(typeof(JumpDecrementSystem))]
  public class JumpingSystem:ComponentSystem{
    ComponentGroup jump;

    protected override void OnCreateManager(){
      jump = GetComponentGroup(
        typeof(Jumping),
        typeof(Player)
      );
    }

    protected override void OnUpdate(){
      var j_entities = jump.GetEntityArray();
      var j_timer = jump.GetComponentDataArray<Jumping>();
      
      for(int i = 0; i < jump.CalculateLength(); i++){
        if(j_timer[i].JumpTime > 0)
          continue;

        PostUpdateCommands.RemoveComponent<Jumping>(j_entities[i]);
        PostUpdateCommands.AddComponent<JumpEnd>(j_entities[i], new JumpEnd{});
      }
    }
  }
}