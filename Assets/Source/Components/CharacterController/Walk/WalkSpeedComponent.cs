
using System;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

namespace RocketJump {
  [Serializable]
  public struct WalkSpeed : IComponentData {
    public float Value;
  }

  public class WalkSpeedComponent : ComponentDataProxy<WalkSpeed> {
  }
}
