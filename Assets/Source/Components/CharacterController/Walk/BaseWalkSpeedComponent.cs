using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump {
  [Serializable]
  public struct BaseWalkSpeed : IComponentData {
    public float Value;
  }

  public class BaseWalkSpeedComponent : ComponentDataProxy<BaseWalkSpeed> { }
}