using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump {
  [Serializable]
  public struct CollidedWithPlayer : IComponentData {
    public Impact Impact;
  }
}