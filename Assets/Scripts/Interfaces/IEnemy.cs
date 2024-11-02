using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    internal interface IEnemy
    {
        Color GetDamegeColor();
        void Hurt();
        void Kill();
    }
}
