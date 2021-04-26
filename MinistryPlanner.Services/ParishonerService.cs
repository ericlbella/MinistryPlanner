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
                                    IndividualId = e.IndividualId,
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

        public ParishonerDetail GetParishonerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Parishoners
                         .Single(e => e.IndividualId == id);
                return
                    new ParishonerDetail
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
                        Officer = entity.Officer,
                        OfficerTitle = entity.OfficerTitle,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }

        }

        public bool UpdateParishoner(ParishonerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Parishoners
                        .Single(e => e.IndividualId == model.IndividualId);
                
                entity.ChurchId = model.ChurchId;
                entity.FirstName = model.FirstName;
                entity.MiddleName = model.MiddleName;
                entity.LastName = model.LastName;
                entity.Email = model.Email;
                entity.HomePhone = model.HomePhone;
                entity.CellPhone = model.CellPhone;
                entity.DateOfBirth = model.DateOfBirth;
                entity.Address = model.Address;
                entity.City = model.City;
                entity.State = model.State;
                entity.Zip = model.Zip;
                entity.Officer = model.Officer;
                entity.OfficerTitle = model.OfficerTitle;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}