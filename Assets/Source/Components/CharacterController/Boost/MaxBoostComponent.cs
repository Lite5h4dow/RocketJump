using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump {
  [Serializable]
  public struct MaxBoost : IComponentData {
    public float Value;
  }

  public class MaxBoostComponent : ComponentDataProxy<MaxBoost> { }
}