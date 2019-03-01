using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump {
  [Serializable]
  public struct BoostTimer : IComponentData {
    public float Value;
  }

  public class BoostTimerComponent : ComponentDataProxy<BoostTimer> { }
}