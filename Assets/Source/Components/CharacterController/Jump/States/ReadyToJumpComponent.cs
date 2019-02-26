using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

namespace RocketJump {
  public struct ReadyToJump : IComponentData {
  }

  public class ReadyToJumpComponent : ComponentDataProxy<ReadyToJump> {
  }
}
