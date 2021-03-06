using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Szkolimy_za_darmo_api.Core.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MaxLength(16)]
        public string PhoneNumber {get; set;}

        [Required]
        public string Name {get; set;}

        [Required]
        public string Surname {get; set;}

        [Required]
        [MaxLength(100)]
        public string Email {get; set;}

        public int BirthYear {get; set;}

        public bool hasDisability {get; set;}
        
        public int SexId {get; set;}

        public int EducationId {get; set;}

        public Sex Sex {get; set;}

        public Education Education {get; set;}

        public DateTime LastUpdate{get; set;}

        public int AreaOfResidenceId {get; set;}

        public AreaOfResidence AreaOfResidence {get; set;}

        public County County {get; set;}

        public int? CountyId {get; set;}

        public Voivodeship Voivodeship {get; set;}

        public int VoivodeshipId {get; set;}

        public MarketStatus MarketStatus {get; set;}
        
        public int MarketStatusId {get; set;}

        public ICollection<Entry> Entries {get; set;}

        public ICollection<UserLog> UserLogs {get; set;}

        public ICollection<Note> Notes {get; set;}

        public ICollection<Comment> Comments {get; set;}
        
        public User(){
            this.Entries = new Collection<Entry>();
            this.UserLogs = new Collection<UserLog>();
            this.Notes = new Collection<Note>();
            this.Comments = new Collection<Comment>();
        }

    }
}