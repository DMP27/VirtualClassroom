using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassroom.Common.Entities;
using VirtualClassroom.WEB.Data.Entities;

namespace VirtualClassroom.WEB.Data
{

    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Field> Fields { get; set; }
        public DbSet<District> Districts { get; set; }

        public DbSet<Church> Churches { get; set; }

        public DbSet<Profession> Professions { get; set; }

        public DbSet<Meeting> Meetings { get; set; }

        public DbSet<Assistance> Assistances { get; set; }

        public DbSet<Classwork> Classworks { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<UserSubject> UserSubjects { get; set; }



        public DbSet<FileClassroom> FileClassrooms { get; set; }

        public DbSet<UserClassWork> UserClassWorks { get; set; }

  


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Profession>()
                .HasIndex(t => t.Name)
                .IsUnique();


            modelBuilder.Entity<Meeting>()
              .HasIndex(t => t.Date)
              .IsUnique();


            modelBuilder.Entity<Assistance>()
              .HasIndex(t => t.Id)
              .IsUnique();





            modelBuilder.Entity<Classwork>()
                .HasIndex(t => t.Id)
                .IsUnique();

            modelBuilder.Entity<Subject>()
                  .HasIndex(t => t.Id)
                  .IsUnique();

            modelBuilder.Entity<UserSubject>()
              .HasIndex(t => t.Id)
              .IsUnique();




            modelBuilder.Entity<FileClassroom>()
             .HasIndex(t => t.Id)
             .IsUnique();

            modelBuilder.Entity<UserClassWork>()
              .HasIndex(t => t.Id)
              .IsUnique();




            modelBuilder.Entity<Field>(fie =>
            {
                fie.HasIndex("Name").IsUnique();
                fie.HasMany(f => f.Districts).WithOne(d => d.Field).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<District>(dist =>
            {
                dist.HasIndex("Name", "FieldId").IsUnique();
                dist.HasOne(d => d.Field).WithMany(f => f.Districts).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Church>(chur =>
            {
                chur.HasIndex("Name", "DistrictId").IsUnique();
                chur.HasOne(c => c.District).WithMany(d => d.Churches).OnDelete(DeleteBehavior.Cascade);
            });


            //modelBuilder.Entity<Meeting>(meet =>
            //{
            //    meet.HasIndex("Date", "IdChurch").IsUnique();
            //    meet.HasOne(m => m.Church).WithMany(c => c.Churches).OnDelete(DeleteBehavior.Cascade);
            //});



        }

    }
}
