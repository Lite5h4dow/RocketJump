using System;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

namespace RocketJump {
  [Serializable]
  public struct MaxJumpHangtime : IComponentData {
    public float Value;
  }

  public class MaxJumpHangtimeComponent : ComponentDataProxy<MaxJumpHangtime> {
  }
}
