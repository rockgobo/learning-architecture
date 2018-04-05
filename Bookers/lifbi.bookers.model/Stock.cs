namespace lifbi.bookers.model
{
    public class Stock : Entity
    {
        //Virtual damit EF in die andere Tabelle gehen kann und die Daten von Buch sich holen
        public virtual Book Book { get; set; }
        public int Amount { get; set; }
    }
}