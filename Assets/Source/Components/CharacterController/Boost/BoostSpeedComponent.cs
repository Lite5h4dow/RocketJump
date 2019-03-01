using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump{
  [Serializable]
  public struct BoostSpeed:IComponentData{
    public float Value;
  }
  public class BoostSpeedComponent : ComponentDataProxy<BoostSpeed>{}
}