using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump{
  [Serializable]
  public struct RocketActive:IComponentData{
    public float Fuel;
  }
  public class RocketActiveComponent : ComponentDataProxy<RocketActive>{}
}