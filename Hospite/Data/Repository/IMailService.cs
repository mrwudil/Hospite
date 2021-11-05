using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospite.Data.Repository
{
    public interface IMailService
    {
        Task SendMailAsync(MailRequest mailRequest);
    }
}
