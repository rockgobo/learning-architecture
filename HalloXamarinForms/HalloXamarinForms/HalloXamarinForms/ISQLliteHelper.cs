using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace HalloXamarinForms
{
    public interface ISQLliteHelper
    {
        SQLiteAsyncConnection GetConnection();
    }
}
