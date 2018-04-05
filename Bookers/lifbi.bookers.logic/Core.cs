using lifbi.bookers.model;
using lifbi.bookers.data.ef;
using System;

namespace lifbi.bookers.logic
{
    public class Core
    {
        public IRepository Repository { get; set; }

        public Core(IRepository repository) => this.Repository = repository;
        public Core() : this(new EFRepository(new EFContext())) { }
    }
}
