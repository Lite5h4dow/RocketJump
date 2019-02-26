using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump {
  [Serializable]
  public struct ReadyToBoost:IComponentData { }
  public class ReadyToBoostComponent : ComponentDataProxy<ReadyToBoost> { }
}