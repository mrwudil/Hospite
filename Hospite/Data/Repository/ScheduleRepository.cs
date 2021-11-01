using Hospite.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospite.Data.Repository
{
    public class ScheduleRepository: IScheduleRepository
    {
        private readonly HospiteDbContext _context;

        public ScheduleRepository(HospiteDbContext context)
        {
            _context = context;
        }


        public async Task<bool> CreateSchedule(Schedule model)
        {
            var addSchedule = _context.Schedules.Add(model);
            if (await _context.SaveChangesAsync() > 0) return false;

            return true;
        }

        public async Task<IEnumerable<Schedule>> GetAllSchedule()
        {
            var getSchedules =await _context.Schedules.Include(x =>x.AppUser).ToListAsync();
            return getSchedules;

        }

        public async Task<Schedule> GetScheduleByTagNumber(string search)
        {
            var res = _context.Schedules.FirstOrDefault(x => x.Tag == search && (x.BookingTime > DateTime.Now.AddHours(-24) && x.BookingTime <= DateTime.Now));

            return res;      
        }

        public async Task<bool> UpdateSchedule(Schedule model)
        {
            _context.Schedules.Update(model);

             if(await _context.SaveChangesAsync() > 0) return true;

            return false;
        }
    }
}
