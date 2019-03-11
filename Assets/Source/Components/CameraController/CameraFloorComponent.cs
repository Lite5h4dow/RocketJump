using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump{
  [Serializable]
  public struct CameraFloor:IComponentData{
    public float Value;
  }
  public class CameraFloorComponent : ComponentDataProxy<CameraFloor>{}
}