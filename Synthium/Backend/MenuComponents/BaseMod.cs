using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Synthium.Backend.MenuComponents;

namespace Synthium.Backend.MenuComponents
{
    public abstract class BaseMod : MonoBehaviour
    {
        public virtual string Name { get; set; } = "Button";
        public virtual ModManager.Categories Category { get; set; } = ModManager.Categories.Main;
        public virtual string Description { get; set; } = "Button";

        public virtual bool ModuleIsEnabled { get; set; } = false;


        public virtual void OnModuleEnable() //called on enable
        {

        }

        public virtual void OnModuleUpdate() //called every frame on enable
        {

        }

        public virtual void OnModuleDisable() //called on disable
        {

        }


    }
}
