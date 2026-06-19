using LibrarySystem.DataAccess.Repositories.Interfaces;
using Microsoft.Data.SqlClient.DataClassification;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.DataAccess.Repositories
{
    public class CounterRepository : ICounterRepository
    {
        public CounterRepository(int x,int y)
        {

        }
        public int Count()
        {
            return 1;
        }

    }
}
