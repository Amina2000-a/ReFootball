﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FootballArea.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FootballAreaDBEntities : DbContext
    {
        public FootballAreaDBEntities()
            : base("name=FootballAreaDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Areas> Areas { get; set; }
        public virtual DbSet<CommentForCustomer> CommentForCustomer { get; set; }
        public virtual DbSet<CommentForReserve> CommentForReserve { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<Rooms> Rooms { get; set; }
        public virtual DbSet<Room_TO_Reservs> Room_TO_Reservs { get; set; }
    }
}
