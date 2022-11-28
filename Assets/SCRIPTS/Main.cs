using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{


    public class Main : MonoBehaviour
    {

        private InputController _inputController;

        private ListExecutObjectController _executObject;

        [SerializeField] private Unit _player;

        private void Awake()
        {
            _inputController = new InputController(_player);

            _executObject = new ListExecutObjectController();

            _executObject.AddExecuteObject(_inputController);
        }


        void Update()
        {
            for (int i = 0; i < _executObject.Lenght; i++)
            {
                if(_executObject.InteractiveObject[i] == null)
                {
                    continue;
                }
                _executObject.InteractiveObject[i].Update();
            }

        }
    }
}
