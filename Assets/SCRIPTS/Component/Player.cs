using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{

    public class Player : Unit
    {
        public override void Awake()
        {
            base.Awake();
            Health = 100;
        }
        public override void Move(float x, float y, float z)
        {
            if (_rb)
            {
                _rb.AddForce(new Vector3(x, y, z) * _speed);
            }
        }

    }
}
