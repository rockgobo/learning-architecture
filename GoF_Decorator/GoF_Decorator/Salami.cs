namespace GoF_Decorator
{
    class Salami : Decorator
    {
        public Salami(IComponent parent) : base(parent) { }

        public override string Text => parent.Text + " Salami";

        public override decimal Price => parent.Price + 3m;
    }
}
