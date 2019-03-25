using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump{
  [UpdateInGroup(typeof(InputGroup))]
  public class RocketReleaseInputSystem:ComponentSystem{
    ComponentGroup rocket;
    ComponentGroup key;

    protected override void OnCreateManager(){
      rocket = GetComponentGroup(
        typeof(RocketActive),
        typeof(Player)
      );
      key = GetComponentGroup(
        typeof(JumpKeyUp)
      );
      RequireForUpdate(rocket);
      RequireForUpdate(key);
    }

    protected override void OnUpdate(){
      var r_entity = rocket.GetEntityArray();
      var r_fuel = rocket.GetComponentDataArray<RocketActive>();
      
      for(int i = 0; i < rocket.CalculateLength(); i++){
        PostUpdateCommands.RemoveComponent<RocketActive>(r_entity[i]);
        PostUpdateCommands.AddComponent<RocketInactive>(r_entity[i], new RocketInactive{
          Value = r_fuel[i].Value
        });
      }
    }
  }
}