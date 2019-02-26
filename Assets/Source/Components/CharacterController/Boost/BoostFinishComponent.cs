using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump {
  [Serializable]
  public struct BoostFinish : IComponentData { }
  public class BoostFinishComponent : ComponentDataProxy<BoostStart> { }
}