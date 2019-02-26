using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump {
  [Serializable]
  public struct BoostEnd : IComponentData {
    public float Value;
  }
  public class BoostEndComponent : ComponentDataProxy<BoostEnd> { }
}