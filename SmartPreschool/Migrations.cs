using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static SmartPreschool.Database;
using static SmartPreschool.Models;

namespace SmartPreschool;

internal class Migrations
{
    public class Groups
    {
        private readonly AppDbContext db;

        public Groups(AppDbContext db) => this.db = db;

        public void Migrate()
        {
            List<Group> defaultGroups = [
                new() { Name = "Ясельная" },
                new() { Name = "Младшая" },
                new() { Name = "Средняя" },
                new() { Name = "Старшая" },
                new() { Name = "Подготовительная" }
            ];

            foreach (var group in defaultGroups)
            {
                db.Groups.Add(group);
            }

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                db.ChangeTracker.Clear();
            }
        }
    }
}
