using System;
using UnityEngine;
using Unity.Mathematics;

namespace SharedCore {
  public static class ExtensionMethods {
    public static System.Random rand = new System.Random();

    public static float2 Normalize (this float2 A) {
      var magnitude = A.Magnitude();
      if (magnitude <= 0)
        return float2.zero;

      return new float2(A.x / magnitude, A.y / magnitude);
    }

    public static float Magnitude (this float2 A) {
      return Mathf.Sqrt((A.x * A.x) + (A.y * A.y));
    }

    public static float2 RandomDirection (this float2 A) {
      return new float2((float)rand.NextDouble() * 1.RandomSign(), (float)rand.NextDouble() * 1.RandomSign()).Normalize();
    }

    public static int RandomSign (this int a) {
      return UnityEngine.Random.Range(0, 2) * 2 - 1;
    }

    public static float2 Left (this float2 A) {
      return new float2(A.y, -A.x);
    }

    public static float2 Right (this float2 A) {
      return new float2(A.y, -A.x) * -1;
    }

    public static float2 RandomLeftOrRight (this float2 A) {
      return 1.RandomSign() == -1 ? A.Right() : A.Left();
    }
    public static float RandomAsRange (this float2 A) {
      return UnityEngine.Random.Range(A.x, A.y);
    }

    public static float2 AsFloat2 (this Vector3 A) {
      return new float2(A.x, A.y);
    }

    public static float3 AsFloat3 (this Vector3 A) {
      return new float3(A.x, A.y, A.z);
    }


    public static float2 AsFloat2 (this Vector2 A) {
      return new float2(A.x, A.y);
    }

    public static float2 AsFloat2 (this float3 A) {
      return new float2(A.x, A.y);
    }

    public static Vector2 AsVector2 (this float3 A) {
      return new Vector2(A.x, A.y);
    }

    public static Vector2 AsVector2 (this float2 A) {
      return new Vector2(A.x, A.y);
    }

    public static Vector2 AsVector2 (this Vector3 A) {
      return new Vector2(A.x, A.y);
    }

    public static Vector3 AsVector3 (this float2 A) {
      return new Vector3(A.x, A.y, 0.0f);
    }

    public static Vector3 AsVector3 (this float3 A) {
      return new Vector3(A.x, A.y, A.z);
    }

    public static float squared (this float a) {
      return a * a;
    }
  }
}