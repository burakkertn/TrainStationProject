using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace TrainStationProject.Models.Entites
{
    public class Station
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string StationName { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string StationAddress { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string StationLocation { get; set; }

       
        public virtual ICollection<Voyage> DepartureStations { get; set; }
        public virtual ICollection<Voyage> ArrivalStations { get; set; }
    }
}
