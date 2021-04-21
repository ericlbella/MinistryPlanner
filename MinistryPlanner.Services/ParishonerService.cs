using MinistryPlanner.Data;
using MinistryPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinistryPlanner.Services
{
    public class ParishonerService
    {
        public bool CreateParishoner(ParishonerCreate model)
        {
            var entity =
                new Parishoner()
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
                    Officer = model.Officer,
                    OfficerTitle = model.OfficerTitle,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Parishoners.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ParishonerListItem> GetParishoners()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Parishoners
                        //.Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ParishonerListItem
                                {
                                    FirstName = e.FirstName,
                                    MiddleName = e.MiddleName,
                                    LastName = e.LastName,
                                    Officer = e.Officer,
                                    OfficerTitle = e.OfficerTitle,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
