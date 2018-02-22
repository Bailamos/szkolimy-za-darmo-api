using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Szkolimy_za_darmo_api.Core.Models
{
    [Table("trainings")]
    public class Training
    {
        public int Id {get; set;}
        [Required]
        [MaxLengthAttribute(255)]
        public string Title {get; set;}
        [Required]
        [MaxLengthAttribute(2000)]
        public string Description {get; set;}
        public DateTime LastUpdate {get; set;}
        public DateTime InsertDate {get; set;}
        public DateTime RegisterSince {get; set;}
        public DateTime RegisterTo {get; set;}
        public ICollection<TrainingTag> Tags {get; set;}
        [Required]
        public string CategoryName { get; set; }  
        public Category Category {get; set;}
        public int MarketStatusId{get; set;}
        public MarketStatus MarketStatus {get; set;}
        public int LocalizationId {get; set;}
        public Localization Localization {get; set;}

        public Training() {
            this.Tags = new Collection<TrainingTag>();
        }
    }
}