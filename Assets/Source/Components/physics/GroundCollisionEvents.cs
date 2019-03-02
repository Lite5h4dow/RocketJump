using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace RocketJump {
  public class GroundCollisionEvents : MonoBehaviour {
    EntityManager em;
    Entity groundEntity;

    private void OnEnable () {
      em = World.Active.GetExistingManager<EntityManager>();
      groundEntity = gameObject.GetComponent<GameObjectEntity>().Entity;
    }
    void OnCollisionEnter2D (Collision2D other) {
      AddImpact(other, State.Overlap.Enter);
    }
    void OnCollisionExit2D (Collision2D other) {
      AddImpact(other, State.Overlap.Exit);
    }
    void OnCollisionStay2D (Collision2D other) {
      AddImpact(other, State.Overlap.Stay);
      Debug.Log("stay");
    }

    void AddImpact (Collision2D collision, State.Overlap state) {
      var collidingEntity = collision.gameObject.GetComponent<GameObjectEntity>();

      if (!collidingEntity)
        return;

      if (!em.HasComponent<CollidedWithGround>(collidingEntity.Entity)) {
        em.AddComponent(collidingEntity.Entity, typeof(CollidedWithGround));
      }

      var impactComponent = new Impact {
        State = state,
        OtherEntity = groundEntity,
        Collision = new CollisionData(collision)
      };

      em.SetComponentData<CollidedWithGround>(collidingEntity.Entity, new CollidedWithGround {
        Impact = impactComponent
      });
    }
  }
}