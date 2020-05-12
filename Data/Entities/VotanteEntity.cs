using Demokratianweb.Data.Infraestructure;
using Demokratianweb.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Demokratianweb.Data.Entities
{
    public class VotanteEntity: BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string RolId { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }

        
    }
    // todo: verificar forenkey con identityuserrole
    //https://stackoverflow.com/questions/56272120/aspnet-identity-custom-identityroleclaim-identityuserrole-identityuserclai
}
