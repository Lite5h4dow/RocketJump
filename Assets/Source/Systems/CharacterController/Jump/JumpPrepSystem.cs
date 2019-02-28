using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump{
  public class JumpPrepSystem:ComponentSystem{
    ComponentGroup jump;

    protected override void OnCreateManager(){
      jump = GetComponentGroup(
        ComponentType.Subtractive(typeof(JumpTimer)),
        typeof(Player),
        typeof(Grounded)
      );
    }

    protected override void OnUpdate(){
      var j_entities = jump.GetEntityArray();
      
      for(int i = 0; i < jump.CalculateLength(); i++){
        PostUpdateCommands.AddComponent<JumpReady>(j_entities[i], new JumpReady{});
      }
    }
  }
}