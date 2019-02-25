using System;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

namespace RocketJump {
  [Serializable]
  public struct Player : IComponentData {
    [HideInInspector] public float2 Value;
  }

  public class PlayerComponent : ComponentDataProxy<Player> {
  }
}
