using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump{
  [Serializable]
  public struct JumpTimer:IComponentData{
    public float Value;
  }
  public class JumpTimerCompnent : ComponentDataProxy<JumpTimer>{}
}