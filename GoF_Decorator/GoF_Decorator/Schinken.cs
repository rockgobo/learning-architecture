namespace GoF_Decorator
{
    class Schinken : Decorator
    {
        public Schinken(IComponent parent) : base(parent) { }

        public override string Text => parent.Text + " Schinken";

        public override decimal Price => parent.Price + 5m;
    }
}
