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
        private readonly string _userId;

        public ChurchService(string userId)
        {
            _userId = userId;
        }

        public bool CreateChurch(ChurchCreate model)
        {
            var entity =
                new Church()
                {
                    //ChurchId = _userId,
                    Name = model.Name,
                    NumberMembers = model.NumberMembers,
                    Phone = model.Phone,
                    Email = model.Email,
                    Address = model.Address,
                    City = model.City,
                    State = model.State,
                    Zip = model.Zip,
                    Denomination = model.Denomination,
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
                        //.Where(e => e.ChurchId == _userId)
                        .Where(e => e.ChurchId == e.ChurchId)


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
                        Address = entity.Address,
                        City = entity.City,
                        State = entity.State,
                        Zip = entity.Zip,
                        Denomination = entity.Denomination,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateChurch(ChurchEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Churches
                        .Single(e => e.ChurchId == model.ChurchId);

                entity.ChurchId = model.ChurchId;
                entity.Name = model.Name;
                entity.NumberMembers = model.NumberMembers;
                entity.Phone = model.Phone;
                entity.Email = model.Email;
                entity.Address = model.Address;
                entity.City = model.City;
                entity.State = model.State;
                entity.Zip = model.Zip;
                entity.Denomination = model.Denomination;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
                        
            }
        }

    }
}