using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump{
  public class RotationConstraintSystem:ComponentSystem{
    ComponentGroup rotator;

    protected override void OnCreateManager(){
      rotator = GetComponentGroup(
        typeof(Player),
        typeof(Rigidbody2D),
        typeof(RotationConstraint)
      );
    }

    protected override void OnUpdate(){
      var r_entities = rotator.GetEntityArray();
      var r_rigidbody2D = rotator.GetComponentArray<Rigidbody2D>();

      for(int i = 0; i < rotator.CalculateLength(); i++){
        r_rigidbody2D[i].constraints = RigidbodyConstraints2D.FreezeRotation;
      }
    }
  }
}