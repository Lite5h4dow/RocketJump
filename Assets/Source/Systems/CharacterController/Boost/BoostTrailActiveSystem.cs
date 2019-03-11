using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump{
  public class BoostTrailActive:ComponentSystem{
    ComponentGroup trail;

    protected override void OnCreateManager(){
      trail = GetComponentGroup(
        typeof(Player),
        typeof(Boosting),
        typeof(TrailRenderer)
      );
    }

    protected override void OnUpdate(){
      var t_entity = trail.GetEntityArray();
      var t_trail = trail.GetComponentArray<TrailRenderer>();
      
      for(int i = 0; i < trail.CalculateLength(); i++){
        t_trail[i].enabled = true;
      }
    }
  }
}