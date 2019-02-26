using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump {
  public class SpinLimitSystem : ComponentSystem {
    ComponentGroup Cube;

    protected override void OnCreateManager(){
      Cube = GetComponentGroup(
        typeof(SpinSpeed),
        typeof(Transform)
      );
    }

    protected override void OnUpdate(){
      var c_entity = Cube.GetEntityArray();
      var c_transform = Cube.GetComponentArray<Transform>();

      for(int i = 0; i<Cube.CalculateLength(); i++){
        // Debug.Log(Mathf.Rad2Deg *c_transform[i].rotation.x);
        if (c_transform[i].eulerAngles.x < 90f)
          continue;

        if (c_transform[i].eulerAngles.x > -90f)
          continue;

        Debug.Log(c_transform[i].name);
        PostUpdateCommands.RemoveComponent<SpinSpeed>(c_entity[i]);

      }
    }
  }
}