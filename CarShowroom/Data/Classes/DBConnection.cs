using CarShowroom.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Data.Classes
{
    internal class DBConnection
    {
        public static CarShowroomEntities connection = new CarShowroomEntities();
    }
}
