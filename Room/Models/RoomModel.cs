using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Room.Models
{
    public class RoomModel
    {
        [Key()]
        public string ID { get; set; }
        [Display(Name="RoomName")]
        public string Name { get; set; }
        
        private string buildingID;

        [Display(Name = "BuildingID")]
        public string BuildingID
        {
            get { return buildingID; }
            set { buildingID = value; }
        }

        public int StudCapacity { get; set; }
        public int ExamCapacity { get; set; }


    }
}