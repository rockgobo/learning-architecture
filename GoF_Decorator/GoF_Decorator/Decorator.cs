using System;
using System.Collections.Generic;
using System.Text;

namespace GoF_Decorator
{
    /// <summary>
    /// Abstrakte Klasse für den Dekorator, dieser hat einen Zeiger auf die Komponente parent
    /// </summary>
    abstract class Decorator : IComponent
    {
        public Decorator(IComponent parent) => this.parent = parent;
        
        protected IComponent parent;

        public abstract string Text { get; }
        public abstract decimal Price { get; }
    }
}
