using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SmartPreschool;

internal class Models
{
    public class Child
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required DateTime BirthDate { get; set; }
        public required string ParentFullName { get; set; }
        public required string ParentPhone { get; set; }
        public required string ResidentialAddress { get; set; }
        public required int GroupId { get; set; }
#pragma warning disable CS8618
        public Group Group { get; set; }
    }

    public class Group
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<Child> Children { get; set; } = [];
    }

    public class Attendance
    {
        public int Id { get; set; }
        public required int ChildId { get; set; }
#pragma warning disable CS8618
        public Child Child { get; set; }
        public required DateTime Date { get; set; }
        public required bool Attended { get; set; }
        public string? Reason { get; set; }
    }
}
