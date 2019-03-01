using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump {
  [Serializable]
  public struct JumpHangtime : IComponentData {
    public float Value;
  }
  public class JumpHangtimeComponent : ComponentDataProxy<JumpHangtime> {
  }
}