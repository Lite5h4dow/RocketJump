using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump{
  [Serializable]
  public struct Impact:IComponentData{
    public State.Overlap State;
    public Entity OtherEntity;
    public CollisionData Collision;
  }
}