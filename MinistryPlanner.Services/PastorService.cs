using MinistryPlanner.Data;
using MinistryPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                                    //NoteId = e.NoteId,
                                    FirstName = e.FirstName,
                                    MiddleName = e.MiddleName,
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
    }
}
