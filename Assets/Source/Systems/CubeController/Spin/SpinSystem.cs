using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RocketJump {
  public class SpinSystem : ComponentSystem {
    ComponentGroup Cube;

    protected override void OnCreateManager () {
      Cube = GetComponentGroup (
        typeof (SpinSpeed),
        typeof (Transform)
      );
    }

    protected override void OnUpdate () {
      var c_entity = Cube.GetEntityArray ();
      var c_transform = Cube.GetComponentArray<Transform> ();
      var c_spinSpeed = Cube.GetComponentDataArray<SpinSpeed> ();

      for (int i = 0; i < Cube.CalculateLength (); i++) {
        c_transform[i].Rotate ((Vector3.right * c_spinSpeed[i].Value) * Time.deltaTime);
      }
    }
  }
}