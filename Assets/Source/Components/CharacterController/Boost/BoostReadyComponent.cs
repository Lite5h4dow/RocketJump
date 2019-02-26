using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump {
  public struct BoostReady : IComponentData { }
  public class BoostReadyComponent : ComponentDataProxy<BoostReady> { }
}