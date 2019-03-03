using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump{
  [Serializable]
  public struct CameraLerpTime:IComponentData{
    public float Value;
  }
  public class CameraLerpTimeComponent : ComponentDataProxy<CameraLerpTime>{}
}