using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump{
  public class JumpEndSystem:ComponentSystem{
    ComponentGroup jump;

    protected override void OnCreateManager(){
      jump = GetComponentGroup(
        typeof(Grounded),
        typeof(JumpEnd),
        typeof(Player)
      );
    }

    protected override void OnUpdate(){
      var j_entity = jump.GetEntityArray();

      for(int i = 0; i < jump.CalculateLength(); i++){
        PostUpdateCommands.RemoveComponent<JumpEnd>(j_entity[i]);
        PostUpdateCommands.AddComponent<JumpReady>(j_entity[i], new JumpReady{});
      }
    }
  }
}