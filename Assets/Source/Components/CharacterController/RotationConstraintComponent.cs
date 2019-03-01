using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump{
  [Serializable]
  public struct RotationConstraint:IComponentData{}
  public class RotationConstraintComponent : ComponentDataProxy<RotationConstraint>{}
}