using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SmartPreschool
{
    internal class Models
    {
        public class Child
        {
            public required int Id { get; set; }
            public required string FullName { get; set; }
            public required DateTime BirthDate { get; set; }
            public required string ParentFullName { get; set; }
            public required string ParentPhone { get; set; }
            public required string ResidentialAddress { get; set; }
            public required int GroupId { get; set; }
            public required Group Group { get; set; }
        }

        public class Group
        {
            public required int Id { get; set; }
            public required string GroupName { get; set; }
            public required List<Child> Children { get; set; }
        }

        public class Attendance
        {
            public required int Id { get; set; }
            public required int ChildId { get; set; }
            public required Child Child { get; set; }
            public required DateTime Date { get; set; }
            public required bool Attended { get; set; }
            public string? Reason { get; set; }
        }
    }
}
