using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump{
  [Serializable]
  public struct CollidedWithGround:IComponentData{
    public Impact Impact;
  }
  public class CollidedWithGroundProxy : ComponentDataProxy<CollidedWithGround>{}
}