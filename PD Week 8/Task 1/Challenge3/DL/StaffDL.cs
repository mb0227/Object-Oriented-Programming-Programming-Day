using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class StaffDL
    {
        private static List<Staff> StaffMembers = new List<Staff>();

        public static void AddStaff(Staff staff)
        {
            StaffMembers.Add(staff);
        }

        public static List<Staff> GetStaff()
        {
            return StaffMembers;
        }
    }
}
