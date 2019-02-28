using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump{
  [Serializable]
  public struct GravityMultiplier:IComponentData{
    public float Value;
  }
  public class GravityMultiplierComponent : ComponentDataProxy<GravityMultiplier>{}
}