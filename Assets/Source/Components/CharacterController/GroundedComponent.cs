using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump{
  [Serializable]
  public struct Grounded:IComponentData{}
  public class GroundedComponent : ComponentDataProxy<Grounded>{}
}