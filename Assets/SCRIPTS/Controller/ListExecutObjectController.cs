using System;
using System.Collections;

using UnityEngine;

namespace Maze
{

    public class ListExecutObjectController
    {
        private IExecute[] _interactiveObject;
        public int Lenght => _interactiveObject.Length;

        public IExecute[] InteractiveObject { get => _interactiveObject; set => _interactiveObject = value; }

        public ListExecutObjectController()
        {

        }
        public void AddExecuteObject(IExecute execute)
        {
            if (InteractiveObject==null)
            {
                InteractiveObject = new[] { execute };
                return;
            }

            Array.Resize(ref _interactiveObject, Lenght + 1);
            InteractiveObject[Lenght - 1] = execute;
        }
    }

}