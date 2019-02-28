using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RocketJump {
  [Serializable]
  public struct CollisionData {
    public CollisionData (Collision2D collision) {
      // deconstruct any collision data into blittable data here
      Contact = collision.contactCount > 0 ? new Contact(collision.GetContact(0)) : new Contact { };
    }
    public Contact Contact;

  }

  public struct Contact {
    public Contact (ContactPoint2D contactPoint) {
      Point = contactPoint.point;
      RelativeVelocity = contactPoint.relativeVelocity;
      Normal = contactPoint.normal;
    }

    public float2 Point;
    public float2 RelativeVelocity;
    public float2 Normal;
  }
}