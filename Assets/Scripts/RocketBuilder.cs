using UnityEngine;

namespace SpaceShipGame
{
    internal sealed class RocketBuilder
    {
        private GameObject _roñket;
        private Rocket _componentRocket;        

        public RocketBuilder InstantiateObject()
        {
            _roñket = Object.Instantiate(Resources.Load<GameObject>("EmptyRocket"));
            return this;
        }

        public RocketBuilder AddComponentRocket(int damage)
        {
            _componentRocket = GetOrAddComponent<Rocket>();
            _componentRocket.InitDamage(damage);
            return this;
        }

        public RocketBuilder AddSprite(Sprite sprite)
        {
            var component = GetOrAddComponent<SpriteRenderer>();
            component.sprite = sprite;
            return this;
        }

        public RocketBuilder AddRigidbody2D(float mass)
        {
            var rigidbody = GetOrAddComponent<Rigidbody2D>();
            rigidbody.gravityScale = 0;
            rigidbody.mass = mass;
            _componentRocket.InitRigidbody(rigidbody);
            return this;
        }

        public RocketBuilder AddCapsuleCollider2D()
        {
            var collider = GetOrAddComponent<CapsuleCollider2D>();
            collider.isTrigger = true;
            return this;
        }

        public RocketBuilder Scale(float value)
        {
            var scale = new Vector3(value, value, _roñket.transform.localScale.z);
            _roñket.transform.localScale = scale;
            return this;
        }
        public Rocket ReturnComponentRocket()
        {
            return _componentRocket;
        }


        private T GetOrAddComponent<T>() where T : Component
        {
            var result = _roñket.GetComponent<T>();
            if (!result)
            {
                result = _roñket.AddComponent<T>();
            }
            return result;
        }
    }
}

