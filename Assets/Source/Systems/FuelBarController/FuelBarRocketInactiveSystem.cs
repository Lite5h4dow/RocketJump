using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine.UI;
using UnityEngine;

namespace RocketJump{
  public class FuelBarRocketInactiveSystem:ComponentSystem{
    ComponentGroup fuel;
    ComponentGroup player;

    protected override void OnCreateManager(){
      fuel = GetComponentGroup(
        typeof(FuelBar),
        typeof(Slider)
      );

      player = GetComponentGroup(
        typeof(Player),
        typeof(MaxRocketFuel),
        typeof(RocketInactive)
      );

      RequireForUpdate(fuel);
      RequireForUpdate(player);
    }

    protected override void OnUpdate(){
      var p_entity = player.GetEntityArray();
      var f_entity = fuel.GetEntityArray();
      var p_fuel = player.GetComponentDataArray<RocketInactive>();
      var p_maxFuel = player.GetComponentDataArray<MaxRocketFuel>();
      var f_value = fuel.GetComponentArray<Slider>();
      
      for(int i = 0; i < fuel.CalculateLength(); i++){
        f_value[i].value = p_fuel[i].Value / p_maxFuel[i].Value;

      }
    }
  }
}