using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIAN.Models
{
    internal static class SelectedEmployee
    {
        private static Employee _employee;

        public static Employee Employee
        {
            get
            {
                return _employee;
            }
            set
            {
                _employee=value;
            }
        }
    }
}
