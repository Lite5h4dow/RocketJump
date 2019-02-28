using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump{
  public class GravityScallingSystem:ComponentSystem{
    ComponentGroup scale;

    protected override void OnCreateManager(){
      scale = GetComponentGroup(
        typeof(Player),
        typeof(GravityMultiplier),
        typeof(Rigidbody2D)
      );
    }

    protected override void OnUpdate(){
      var s_entities = scale.GetEntityArray();
      var s_rigidbodies = scale.GetComponentArray<Rigidbody2D>();
      var s_gravityScalar = scale.GetComponentDataArray<GravityMultiplier>();
      
      for(int i = 0; i < scale.CalculateLength(); i++){
        s_rigidbodies[i].gravityScale = s_gravityScalar[i].Value;
        PostUpdateCommands.RemoveComponent<GravityMultiplier>(s_entities[i]);
      }
    }
  }
}