using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump{
  public class RocketInputSystem:ComponentSystem{
    ComponentGroup rocket;
    ComponentGroup key;

    protected override void OnCreateManager(){
      rocket = GetComponentGroup(
        ComponentType.Subtractive(typeof(Grounded)),
        typeof(Player),
        typeof(RocketInactive)
      );

      key = GetComponentGroup(
        typeof(JumpKeyDown)
      );

      RequireForUpdate(rocket);
      RequireForUpdate(key);
    }

    protected override void OnUpdate(){
      var r_entity = rocket.GetEntityArray();
      var r_fuelCharge = rocket.GetComponentDataArray<RocketInactive>();
      
      for(int i = 0; i < rocket.CalculateLength(); i++){
        PostUpdateCommands.RemoveComponent<RocketInactive>(r_entity[i]);
        PostUpdateCommands.AddComponent<RocketActive>(r_entity[i], new RocketActive{
          Value = r_fuelCharge[i].Value
        });
      }
    }
  }
}