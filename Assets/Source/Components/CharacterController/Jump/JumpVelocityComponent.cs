using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump{
  [Serializable]
  public struct JumpVelocity:IComponentData{
    public float Velocity;
  }
  public class JumpVelocityComponent : ComponentDataProxy<JumpVelocity>{}
}