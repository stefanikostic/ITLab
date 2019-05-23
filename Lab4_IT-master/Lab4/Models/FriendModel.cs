using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab4.Models
{
    public class FriendModel
    {
        [Required]
        [Range(0,200)]
        [Key]
        public int Id { set; get; }
        [Required]
        public string Ime { set; get; }
        [Required]
        public string MestoZiveenje { set; get;}
    }

    public class FriendContext: DbContext
    {
        public DbSet<FriendModel> allfriends { get; set; }

        public FriendContext() : base("DefaultConnection")
        {
            
        }
    }
}