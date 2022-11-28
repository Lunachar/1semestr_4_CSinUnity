using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public abstract class Unit : MonoBehaviour
    {
        public Transform _transform;
        public Rigidbody _rb;

        public float _speed = 5f;
        private int _health = 100;
        public bool _isDeath;

        public int Health
        {
            get
            {
                return _health;
            }

            set
            {
                if (value <= 100 && value >= 0)
                {
                    _health = value;
                }
                else
                {
                    _health = 100;
                    Debug.Log("Wrong Number");
                }

            }
        }

        public virtual void Awake()
        {
            if(!TryGetComponent<Transform>(out _transform))
            {
                Debug.Log("No Transform Component!");
            }
            if (!TryGetComponent<Rigidbody>(out _rb))
            {
                Debug.Log("No Rigidbody Component!");
            }

        }

        public abstract void Move(float x, float y, float z);
    }

}
