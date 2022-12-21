using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

namespace Maze
{
    public class BadBonus : Bonus, IFly, IRotation
    {
        private float heightFly;
        [SerializeField]private float speedRotation;

        public event Action<string, Color> OnCaughtPlayer = delegate (string str, Color color) { };


        //protected Color _colorBad;
        //private Renderer _rendererBadB = Transform.;

        public override void Awake()
        {
            base.Awake();
            heightFly = Random.Range(1f, 5f);
            speedRotation = Random.Range(25f, 100f);
            _color = Random.ColorHSV();
            _renderer.sharedMaterial.color = _color;

        }

        public void Fly()
        {
            _transform.position = new Vector3(_transform.position.x, Mathf.PingPong(Time.time, heightFly+1), _transform.position.z);
        }
        public void Rotate()
        {
            _transform.Rotate(Vector3.up * (Time.deltaTime * speedRotation), Space.World);
        }


        public override void Update()
        {
            Fly();
            Rotate();
        }
        protected override void Interaction()
        {
            IsInteractable = false;
            OnCaughtPlayer.Invoke(gameObject.name, _color);
        }
    }
}
