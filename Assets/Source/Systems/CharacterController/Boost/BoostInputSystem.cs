using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump {
  public class BoostInputSystem : ComponentSystem {
    ComponentGroup player;
    ComponentGroup input;

    protected override void OnCreateManager () {
      player = GetComponentGroup (
        typeof (Player),
        typeof (ReadyToBoost),
        typeof (WalkSpeed)
      );
      input = GetComponentGroup(
        typeof(BoostKeyDown)
      );

      RequireForUpdate(player);
      RequireForUpdate(input);
    }

    protected override void OnUpdate () {
      var p_entity = player.GetEntityArray ();
      var p_walkSpeed = player.GetComponentDataArray<WalkSpeed> ();

      for (int i = 0; i < player.CalculateLength (); i++) {
        PostUpdateCommands.RemoveComponent<ReadyToBoost> (p_entity[i]);
        PostUpdateCommands.AddComponent<BoostReady> (p_entity[i], new BoostReady { });

      }

    }
  }
}