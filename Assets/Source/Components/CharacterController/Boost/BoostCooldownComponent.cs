using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump {
  [Serializable]
  public struct BoostCooldown : IComponentData {
    public float Value;
  }

  public class BoostCooldownComponent : ComponentDataProxy<BoostCooldown> { }
}