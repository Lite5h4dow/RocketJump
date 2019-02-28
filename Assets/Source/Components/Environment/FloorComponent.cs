using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump{
  [Serializable]
  public struct Floor:IComponentData{}
  public class FloorComponent : ComponentDataProxy<Floor>{}
}