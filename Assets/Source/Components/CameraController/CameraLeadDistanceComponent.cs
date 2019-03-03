using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump{
  [Serializable]
  public struct CameraLeadDistance:IComponentData{
    public float Value;
  }
  public class CameraLeadDistanceComponent : ComponentDataProxy<CameraLeadDistance>{}
}