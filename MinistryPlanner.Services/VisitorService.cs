using MinistryPlanner.Data;
using MinistryPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinistryPlanner.Services
{
    public class VisitorService
    {
        public bool CreateVisitor(VisitorCreate model)
        {
            var entity =
                new Visitor()
                {
                    ChurchId = model.ChurchId,
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    Email = model.Email,
                    HomePhone = model.HomePhone,
                    CellPhone = model.CellPhone,
                    DateOfBirth = model.DateOfBirth,
                    Address = model.Address,
                    City = model.City,
                    State = model.State,
                    Zip = model.Zip,
                    DateVisited = model.DateVisited,
                    CreatedUtc = DateTimeOffset.Now

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Visitors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<VisitorListItem> GetVisitors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Visitors
                        //.Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new VisitorListItem
                                {
                                    IndividualId = e.IndividualId,
                                    FirstName = e.FirstName,
                                    MiddleName = e.MiddleName,
                                    LastName = e.LastName,
                                    DateVisited = e.DateVisited,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }

        public VisitorDetail GetVisitorById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                         .Visitors
                         .Single(e => e.IndividualId == id);
                return
                    new VisitorDetail
                    {
                        Name = entity.Church.Name,
                        //IndividualId = entity.IndividualId,
                        //ChurchId = entity.ChurchId,
                        FirstName = entity.FirstName,
                        MiddleName = entity.MiddleName,
                        LastName = entity.LastName,
                        Email = entity.Email,
                        HomePhone = entity.HomePhone,
                        CellPhone = entity.CellPhone,
                        DateOfBirth = entity.DateOfBirth,
                        Address = entity.Address,
                        City = entity.City,
                        State = entity.State,
                        Zip = entity.Zip,
                        DateVisited = entity.DateVisited,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc

                    };
            }

        }
    }
    
}

