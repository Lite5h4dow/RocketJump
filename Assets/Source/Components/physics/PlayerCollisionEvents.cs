using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace RocketJump {
  public class PlayerCollisionEvents : MonoBehaviour {
    EntityManager em;
    Entity playerEntity;

    private void OnEnable () {
      em = World.Active.GetExistingManager<EntityManager> ();
      playerEntity = gameObject.GetComponent<GameObjectEntity> ().Entity;
    }
    void OnCollisionEnter2D (Collision2D other) {
      AddImpact(other, State.Overlap.Enter);
    }
    void OnCollisionExit2D (Collision2D other) {
      AddImpact(other, State.Overlap.Exit);
    }
    void OnCollisionStay2D (Collision2D other) {
      AddImpact(other, State.Overlap.Stay);
    }

    void AddImpact (Collision2D collision, State.Overlap state) {
      var collidingEntity = collision.gameObject.GetComponent<GameObjectEntity> ();

      if (!collidingEntity)
        return;

      if (!em.HasComponent<CollidedWithPlayer> (collidingEntity.Entity)) {
        em.AddComponent (collidingEntity.Entity, typeof (CollidedWithPlayer));
      }

      var impactComponent = new Impact {
        State = state,
        OtherEntity = playerEntity,
        Collision = new CollisionData (collision)
      };

      em.SetComponentData<CollidedWithPlayer> (collidingEntity.Entity, new CollidedWithPlayer {
        Impact = impactComponent
      });
    }
  }
}