using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump{
  [Serializable]
  public struct MaxRocketFuel:IComponentData{
    public float Value;
  }
  public class MaxRocketFuelComponent : ComponentDataProxy<MaxRocketFuel>{}
}