using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainStationProject.Models.Entites
{
    public class Voyage
    {
        public int Id { get; set; }
        public int DepartureStationId { get; set; }
        public Station DepartureStation { get; set; }
        public int ArrivalStationId { get; set; }
        public Station ArrivalStation { get; set; }

        public int StationId { get; set; }
        public Station Station { get; set; }


        [Column(TypeName = "DateTime2")]
        public DateTime DepartureTime { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime ArrivalTime { get; set; }
    }
}
