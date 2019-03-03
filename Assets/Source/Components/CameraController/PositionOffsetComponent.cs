using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump {
  [Serializable]
  public struct PositionOffset : IComponentData {
    public float3 Value;
  }
  public class PositionOffsetComponent : ComponentDataProxy<PositionOffset> {
  }
}