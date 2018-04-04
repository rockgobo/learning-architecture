namespace GoF_Decorator
{
    class Käse : Decorator
    {
        public Käse(IComponent parent) : base(parent){}
        
        public override string Text => parent.Text + " Käse";

        public override decimal Price => parent.Price + 0.5m;
    }
}
