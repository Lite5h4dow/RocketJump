using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump{
  [Serializable]
  public struct FuelBar:IComponentData{}
  public class FuelBarComponent : ComponentDataProxy<FuelBar>{}
}