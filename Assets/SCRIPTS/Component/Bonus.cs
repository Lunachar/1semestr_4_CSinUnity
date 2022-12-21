using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{

    public abstract class Bonus : MonoBehaviour, IExecute
    {

        private bool _isInteractable;
        public Transform _transform;
        protected Color _color;

        protected Renderer _renderer;
        private Collider _collider;

        public float _hightFly;

        public bool IsInteractable 
        { 
            get => _isInteractable;
            set
            {
                _isInteractable = value;
                _renderer.enabled = value;
                _collider.enabled = value;
            }  
        }

        public virtual void Awake()

        {
            if (!TryGetComponent<Renderer>(out _renderer))
            {
                Debug.Log("No Renderer Component!");
            }
            if (!TryGetComponent<Collider>(out _collider))
            {
                Debug.Log("No Collider Component!");
            }

        }

        void Start()
        {
            IsInteractable = true;
            _color = Random.ColorHSV();

            if(TryGetComponent(out Renderer renderer))
            {
                renderer.sharedMaterial.color = _color;

            }


            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (IsInteractable||other.CompareTag("Player"))
            {
                Interaction();
                IsInteractable = false;
            }
        }

        protected abstract void Interaction();
        public abstract void Update();
        
    }
}
