using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Maze
{

    public sealed class ListExecuteObjectController: IEnumerable, IEnumerator//, IDisposable
    {
        private IExecute[] _interactiveObject;
        private int _index = -1;

        public object Current => _interactiveObject[_index]; // Текущий элемент коллекции
        public int Length => _interactiveObject.Length;

        //private List<IExecute> temp;


        public ListExecuteObjectController()
        {
            Bonus[] BonusObject = Object.FindObjectsOfType<Bonus>();
            for (int i = 0; i < BonusObject.Length; i++)
            {
                if (BonusObject[i] is IExecute intObj)
                {
                    AddExecuteObject(intObj);
                }
            }
        }


        public IExecute this[int curr]
        {
            get => _interactiveObject[curr];
            private set => _interactiveObject[curr] = value; 
        }

        public ListExecuteObjectController(Bonus[] bonuses)
        {
            for (int i = 0; i < bonuses.Length; i++)
            {
                if (bonuses[i] is IExecute intObject)
                {
                    AddExecuteObject(intObject);
                }
            }
        }



        public void AddExecuteObject(IExecute execute)
        {
            if (_interactiveObject==null)
            {
                _interactiveObject = new[] { execute };
                return;
            }

            Array.Resize(ref _interactiveObject, Length + 1);
            _interactiveObject[Length - 1] = execute;
        }

        ///////
        ///
        public bool MoveNext() // Перемещение на одну позицию вперед
        {
            if (_index == Length-1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }

        public void Reset() // Перемещение в начало коллекции
        {
            _index = -1;
        }
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        //public void Dispose()
        //{
        //    temp.Clear();
        //}





    }

}