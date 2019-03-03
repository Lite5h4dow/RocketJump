using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump {
  [Serializable]
  public struct TrackingSpeed : IComponentData {
    public float Value;
  }
  public class TrackingSpeedComponent : ComponentDataProxy<TrackingSpeed> {
  }
}