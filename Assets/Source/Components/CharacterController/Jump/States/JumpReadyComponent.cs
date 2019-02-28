using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

namespace RocketJump {
  public struct JumpReady : IComponentData {
  }

  public class JumpReadyComponent : ComponentDataProxy<JumpReady> {
  }
}
