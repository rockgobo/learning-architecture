using System;
using System.Collections.Generic;
using System.Text;

namespace lifbi.bookers.model
{
    public interface IUnitOfWork
    {
        IBookShopRepository BookShopRepository { get; } // Ganz streng: 1 Repo pro Datentyp

        /// <summary>
        /// Entscheidet welches Repository nach außen gegeben wird, je nachdem welcher Datentyp angefragt wird
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IUnitOfWorkRepository<T> GetRepository<T>() where T : Entity;

        void Save();
    }
}
