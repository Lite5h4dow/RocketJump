using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump {
  [Serializable]
  public struct SpinSpeed : IComponentData {
    public float Value;
  }
  public class SpinSpeedComponent : ComponentDataProxy<SpinSpeed> { }
}