using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump{
  [Serializable]
  public struct CameraLeadDirection:IComponentData{
    public float Value;
  }
  public class CameraLeadDirectionComponent : ComponentDataProxy<CameraLeadDirection>{}
}