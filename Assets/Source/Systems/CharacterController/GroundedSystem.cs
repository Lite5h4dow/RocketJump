using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump {
  [UpdateAfter(typeof(UnityEngine.Experimental.PlayerLoop.FixedUpdate))]
  public class GroundedSystem : ComponentSystem {
    ComponentGroup grounded;

    protected override void OnCreateManager () {
      grounded = GetComponentGroup(
        ComponentType.Subtractive(typeof(Grounded)),
        typeof(Player),
        typeof(CollidedWithGround)
      );
    }

    protected override void OnUpdate () {
      var g_player = grounded.GetEntityArray();

      for (int i = 0; i < grounded.CalculateLength(); i++) {
        PostUpdateCommands.AddComponent<Grounded>(g_player[i], new Grounded { });

        /* ----------------- DEVELOPER SETTINGS - REMOVE ME -------------------- */
        if (Bootstrap.DeveloperSettings.DebugGroundedState) {
          Debug.Log($"<color=green>{this.GetType()}</color> Grounded");
        }
        /* ----------------- DEVELOPER SETTINGS - REMOVE ME -------------------- */
      }
    }
  }
}