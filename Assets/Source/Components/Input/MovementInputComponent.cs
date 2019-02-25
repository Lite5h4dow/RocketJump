using System;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

namespace RocketJump {
  [Serializable]
  public struct MovementInput : IComponentData {
    [HideInInspector] public float2 Value;
  }

  public class MovementInputComponent : ComponentDataProxy<MovementInput> {
  }
}
