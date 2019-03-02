using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump{
  [Serializable]
  public struct JumpEnd:IComponentData{}
  public class JumpEndComponent : ComponentDataProxy<JumpEnd>{}
}