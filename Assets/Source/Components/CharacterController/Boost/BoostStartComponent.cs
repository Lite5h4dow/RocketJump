using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump {
  [Serializable]
  public struct BoostStart : IComponentData { }
  public class BoostStartComponent : ComponentDataProxy<BoostStart> { }
}