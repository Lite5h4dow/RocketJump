using System;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

namespace RocketJump {
  [Serializable]
  public struct JumpSpeed : IComponentData {
    public float Value;
  }

  public class JumpSpeedComponent : ComponentDataProxy<JumpSpeed> {
  }
}
