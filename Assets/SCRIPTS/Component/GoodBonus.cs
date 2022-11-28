using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{


    public class GoodBonus : Bonus
    {

        public override void Awake()
        {
            base.Awake();
            //init bonus point, material, height fly
        }


        public override void Update()
        {
            //fly
            //flick

        }

        protected override void Interaction()
        {
            IsInteractable = false;
            //Add point
        }
    }

}