using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthium.Backend.MenuComponents
{
    internal class Button
    {
        public string buttonText = "nil";
        public Action method;
        public Action enableMethod;
        public Action disable;
        public bool enabled = false;
        public bool toggle = true;
    }
}
