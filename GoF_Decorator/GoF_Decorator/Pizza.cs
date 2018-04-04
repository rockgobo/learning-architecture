using System;
using System.Collections.Generic;
using System.Text;

namespace GoF_Decorator
{
    /// <summary>
    /// Implements Dekorator und Builder pattern
    /// </summary>
    public class Pizza : IComponent
    {
        string IComponent.Text => "Pizza";

        decimal IComponent.Price => 6m;

        public static Builder Bäcker = new Builder();
            
        public class Builder
        {
            IComponent customPizza = new Pizza();

            public Builder mitKäse()
            {
                customPizza = new Käse(customPizza);
                return this;
            }

            public Builder mitSalami()
            {
                customPizza = new Salami(customPizza);
                return this;
            }

            public Builder mitSchinken()
            {
                customPizza = new Schinken(customPizza);
                return this;
            }

            public IComponent Generate()
            {
                return customPizza;
            }
        } 
    }
}
