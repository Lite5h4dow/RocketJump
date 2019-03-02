using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump{
  [Serializable]
  public struct RocketInactive:IComponentData{
    public float Value;
  }
  public class RocketInactiveComponent : ComponentDataProxy<RocketInactive>{}
}