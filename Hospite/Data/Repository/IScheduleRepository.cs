using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospite.Data.Repository
{
    public interface IScheduleRepository
    {
        Task<bool> CreateSchedule(Schedule model);
        Task<Schedule> GetScheduleByTagNumber(string search);
        Task<IEnumerable<Schedule>> GetAllSchedule();
        Task<bool> UpdateSchedule(Schedule model);
        Task<bool> TagExist(string tag);
        int Notification();
    }
}
