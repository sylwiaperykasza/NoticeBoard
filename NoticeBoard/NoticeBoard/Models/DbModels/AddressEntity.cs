using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoticeBoard.Models.DbModels
{
    [Table("Address")]
    public class AddressEntity
    {
        [Key]
        public int Id { get; set; }
        public string City { get; set; }
        public string StreetAndNumber { get; set; }
        public string PostalCode { get; set; }

        public virtual UserProfileEntity UserProfile { get; set; }
    }
}