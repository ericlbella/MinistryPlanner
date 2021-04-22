using MinistryPlanner.Data;
using MinistryPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinistryPlanner.Services
{
    public class ChurchService
    {
        //private readonly Guid _userId;

        //public ChurchService(Guid userId)
        //{
        //    _userId = userId;
        //}

        public bool CreateChurch(ChurchCreate model)
        {
            var entity =
                new Church()
                {
                    //OwnerId = _userId,
                    Name = model.Name,
                    NumberMembers = model.NumberMembers,
                    Phone = model.Phone,
                    Email = model.Email,
                    Address = model.Address,
                    City = model.City,
                    StateOfChurch = model.StateOfChurch,
                    Zip = model.Zip,
                    DenominationOfChurch = model.DenominationOfChurch,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Churches.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ChurchListItem> GetChurches()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Churches
                        //.Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ChurchListItem
                                {
                                    ChurchId = e.ChurchId,
                                    Name = e.Name,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }

        public ChurchDetail GetChurchById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Churches
                        .Single(e => e.ChurchId == id);
                return
                    new ChurchDetail
                    {
                        ChurchId = entity.ChurchId,
                        Name = entity.Name,
                        NumberMembers = entity.NumberMembers,
                        Phone = entity.Phone,
                        Email = entity.Email,
                        City = entity.City,
                        StateOfChurch = entity.StateOfChurch,
                        Zip = entity.Zip,
                        DenominationOfChurch = entity.DenominationOfChurch,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
    }
}