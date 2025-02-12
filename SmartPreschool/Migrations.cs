using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static SmartPreschool.Database;
using static SmartPreschool.Models;

namespace SmartPreschool
{
    internal class Migrations
    {
        public class Groups
        {
            private AppDbContext db;

            public Groups(AppDbContext db)
            {
                this.db = db;
            }

            public void Migrate()
            {
                var defaultGroups = new List<Group> {
                    new Group { Name = "Ясельная" },
                    new Group { Name = "Младшая" },
                    new Group { Name = "Средняя" },
                    new Group { Name = "Старшая" },
                    new Group { Name = "Подготовительная" }
                };

                foreach (var group in defaultGroups)
                {
                    try
                    {
                        db.Groups.Add(group);
                        db.SaveChanges();
                    }
                    catch (DbUpdateException)
                    {
                        db.ChangeTracker.Clear();
                    }
                }
            }
        }
    }
}
