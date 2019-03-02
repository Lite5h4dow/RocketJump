using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump{
  [Serializable]
  public struct JumpReady:IComponentData{}
  public class JumpReadyComponent : ComponentDataProxy<JumpReady>{}
}