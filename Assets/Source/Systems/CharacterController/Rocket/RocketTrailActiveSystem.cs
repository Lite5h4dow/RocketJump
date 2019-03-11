using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump{
  public class RocketTrailActiveSystem:ComponentSystem{
    ComponentGroup effect;

    protected override void OnCreateManager(){
      effect = GetComponentGroup(
        typeof(Player),
        typeof(RocketActive),
        typeof(ParticleSystem)
      );
    }

    protected override void OnUpdate(){
      var e_entity = effect.GetEntityArray();
      var e_particle = effect.GetComponentArray<ParticleSystem>();
      
      for(int i = 0; i < effect.CalculateLength(); i++){
        if(e_particle[i].isEmitting)
          continue;

        e_particle[i].Play();
      }
    }
  }
}