using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump {
  [Serializable]
  public struct BoostReady : IComponentData { 
    public float Value;
  }
  public class BoostReadyComponent : ComponentDataProxy<BoostReady> { }
}