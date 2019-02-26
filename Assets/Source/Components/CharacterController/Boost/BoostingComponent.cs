using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump {
  [Serializable]
  public struct Boosting : IComponentData { 
    public float Value;
  }
  public class BoostingComponent : ComponentDataProxy<Boosting> { }
}