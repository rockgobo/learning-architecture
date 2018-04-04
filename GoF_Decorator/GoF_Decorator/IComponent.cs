using System;
using System.Collections.Generic;
using System.Text;

namespace GoF_Decorator
{
    /// <summary>
    /// Interface für die Komponenten in der Dekoratoren Hierarchie
    /// </summary>
    public interface IComponent
    {
        string Text { get; }
        decimal Price { get; }
    }
}
