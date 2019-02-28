using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump{
  [Serializable]
  public struct JumpStart:IComponentData{}
  public class JumpStartComponent : ComponentDataProxy<JumpStart>{}
}