using Demokratianweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demokratianweb.HubRT
{
    public interface ITypedHubClient
    {
        Task NotificarNuevaRonda(Message msg);
        Task NotificarVoto(Message msg);
    }
}
