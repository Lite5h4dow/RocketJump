using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

namespace RocketJump {
  public struct Jumping : IComponentData {
    public float Hangtime;
  }
}
