using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump{
  [UpdateAfter(typeof(CameraTrackingSystem))]
  public class CameraClampSystem:ComponentSystem{
    ComponentGroup clamp;

    protected override void OnCreateManager(){
      clamp = GetComponentGroup(
        typeof(Camera),
        typeof(PositionOffset),
        typeof(Transform),
        typeof(CameraFloor)
      );
    }

    protected override void OnUpdate(){
      var c_entity = clamp.GetEntityArray();
      var c_transform = clamp.GetComponentArray<Transform>();
      var c_floor = clamp.GetComponentDataArray<CameraFloor>();
      
      for(int i = 0; i < clamp.CalculateLength(); i++){
        if(c_transform[i].position.y > c_floor[i].Value)
          continue;

        c_transform[i].position = new Vector3(
          c_transform[i].position.x,
          c_floor[i].Value,
          c_transform[i].position.z
        );
      }
    }
  }
}