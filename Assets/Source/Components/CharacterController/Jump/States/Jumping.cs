using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump {
  [Serializable]
  public struct Jumping : IComponentData {
    public float Hangtime;
  }
}