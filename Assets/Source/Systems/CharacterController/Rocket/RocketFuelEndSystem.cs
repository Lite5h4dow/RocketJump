using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump{
  public class RocketFuelEndSystem:ComponentSystem{
    ComponentGroup fuel;

    protected override void OnCreateManager(){
      fuel = GetComponentGroup(
        typeof(RocketActive)
      );
    }

    protected override void OnUpdate(){
      var f_entities = fuel.GetEntityArray();
      var f_fuel = fuel.GetComponentDataArray<RocketActive>();
      
      for(int i = 0; i < fuel.CalculateLength(); i++){
        if(f_fuel[i].Fuel > 0)
          continue;
        
        PostUpdateCommands.RemoveComponent<RocketActive>(f_entities[i]);
        PostUpdateCommands.AddComponent<RocketInactive>(f_entities[i], new RocketInactive{});
      }
    }
  }
}