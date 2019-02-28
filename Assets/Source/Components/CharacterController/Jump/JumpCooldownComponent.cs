using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump{
  [Serializable]
  public struct JumpCooldown:IComponentData{
    public float Value;
  }
  public class JumpCooldownComponent : ComponentDataProxy<JumpCooldown>{}
}