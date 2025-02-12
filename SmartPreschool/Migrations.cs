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
            HashSet<string> defaultGroups = [
                "Ясельная",
                "Младшая",
                "Средняя",
                "Старшая",
                "Подготовительная"
            ];

            var groups = db.Groups.Select(g => g.Name).ToList();

            defaultGroups.ExceptWith(groups);

            foreach (var group in defaultGroups)
            {
                db.Groups.Add(new() { Name = group });
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
