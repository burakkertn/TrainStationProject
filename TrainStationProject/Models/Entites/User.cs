using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainStationProject.Models.Entites
{
    public class User
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Username { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Password { get; set; }
    }
}
