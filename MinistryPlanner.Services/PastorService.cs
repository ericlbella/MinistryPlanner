using MinistryPlanner.Data;
using MinistryPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MinistryPlanner.Services
{
    public class PastorService
    {
        //private readonly Guid _userId;

        ////public PastorService(Guid userId)
        //{
        //    _userId = userId;
        //}
        public bool CreatePastor(PastorCreate model)
        {
            var entity =
                new Pastor()
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
                    State = (State)model.State,
                    Zip = model.Zip,
                    SeniorPastor = model.SeniorPastor,
                    AssistantPastor = model.AssistantPastor,
                    YouthPastor = model.YouthPastor,
                    SongLeader = model.SongLeader,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Pastors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<PastorListItem> GetPastors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Pastors
                        //.Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new PastorListItem
                                {
                                    IndividualId = e.IndividualId,
                                    FirstName = e.FirstName,
                                    MiddleName = e.MiddleName,
                                    LastName = e.LastName,
                                    SeniorPastor = e.SeniorPastor,
                                    AssistantPastor = e.AssistantPastor,
                                    YouthPastor = e.YouthPastor,
                                    SongLeader = e.SongLeader,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }

        public PastorDetail GetPastorById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                         .Pastors
                         .Single(e => e.IndividualId == id);
                return
                    new PastorDetail
                    {
                        Name = entity.Church.Name,
                        IndividualId = entity.IndividualId,
                        ChurchId = entity.ChurchId,
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
                        SeniorPastor = entity.SeniorPastor,
                        AssistantPastor = entity.AssistantPastor,
                        YouthPastor = entity.YouthPastor,
                        SongLeader = entity.SongLeader,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }

        }

        public bool UpdatePastor(PastorEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Pastors
                        .Single (e => e.IndividualId == model.IndividualId);

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
                entity.SeniorPastor = model.SeniorPastor;
                entity.AssistantPastor = model.AssistantPastor;
                entity.YouthPastor = model.YouthPastor;
                entity.SongLeader = model.SongLeader;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;



                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeletePastor(int IndividualId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Pastors
                        .Single(e => e.IndividualId == IndividualId);

                ctx.Pastors.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        private static PastorService CreatePastorService()
        {
            return new PastorService();
        }


    }

}