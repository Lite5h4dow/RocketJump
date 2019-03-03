using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump{
  [Serializable]
  public struct RocketVelocity:IComponentData{
    public float Value;
  }
  public class RocketVelocityComponent : ComponentDataProxy<RocketVelocity>{}
}