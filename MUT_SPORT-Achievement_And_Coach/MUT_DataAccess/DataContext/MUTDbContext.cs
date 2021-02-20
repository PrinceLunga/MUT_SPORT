using Microsoft.EntityFrameworkCore;
using MUT_DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUT_DataAccess.DataContext
{
    public class MUTDbContext : DbContext
    {
        public MUTDbContext(DbContextOptions<MUTDbContext> options):base(options)
        {
        }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Student>  Students { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<TrainingSchedule> TrainingSchedules { get; set; }
        public DbSet<GameResult> GameResults { get; set; }
        public DbSet<StudentSport> StudentSports{ get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<PlayerAchievement> PlayerAchievements { get; set; }
        public DbSet<TeamAchievement> TeamAchievements { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<TeamPlayer> TeamPlayers { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UpComingEvent> UpComingEvents { get; set; }
        public DbSet<Residence> Residences { get; set; }

    }
}
