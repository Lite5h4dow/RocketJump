using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump {
  public class UndoBoostSystem : ComponentSystem {
    ComponentGroup boost;

    protected override void OnCreateManager () {
      boost = GetComponentGroup (
        typeof (Player),
        typeof (BaseWalkSpeed),
        typeof (WalkSpeed),
        typeof (BoostEnd)
      );
    }

    protected override void OnUpdate () {
      var b_entities = boost.GetEntityArray ();
      var b_BaseWalkSpeed = boost.GetComponentDataArray<BaseWalkSpeed> ();

      for (int i = 0; i < boost.CalculateLength (); i++) {
        EntityManager.SetComponentData (b_entities[i], new WalkSpeed {
          Value = b_BaseWalkSpeed[i].Value
        });
      }
    }
  }
}