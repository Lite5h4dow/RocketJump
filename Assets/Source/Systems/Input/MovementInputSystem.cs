using UnityEngine;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace RocketJump {
  [UpdateInGroup(typeof(InputGroup))]
  public class MovementInputSystem : ComponentSystem {
    ComponentGroup player;

    protected override void OnCreateManager () {
      player = GetComponentGroup(
        typeof(MovementInput)
      );
    }

    protected override void OnUpdate () {
      var p_entity = player.GetEntityArray();

      for (int i = 0; i < player.CalculateLength(); i++) {
        var movement = float2.zero;

        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        EntityManager.SetComponentData<MovementInput>(p_entity[i], new MovementInput {
          Value = movement
        });
      }
    }
  }
}