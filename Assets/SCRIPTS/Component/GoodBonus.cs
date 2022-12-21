using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Maze
{


    public class GoodBonus : Bonus, IFly, IFlicker
    {
        private float heightFly = 3f;
        [SerializeField] private Material _material;
        public int Point = 1;

        public event Action<int> AddPoints = delegate (int i) { };

        public override void Awake()
        {
            base.Awake();
            _material = GetComponent<Renderer>().material;
            //init bonus point, material, height fly
        }


        public override void Update()
        {
            Fly();
            Flick();
        }

        public void Fly()
        {
            _transform.position = new Vector3(_transform.position.x, Mathf.PingPong(Time.time, heightFly), _transform.position.z);
        }

        public void Flick()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, Mathf.PingPong(Time.time, 1.0f));
        }
        protected override void Interaction()
        {
            IsInteractable = false;
            AddPoints.Invoke(Point);
            //Add point
        }
    }

}