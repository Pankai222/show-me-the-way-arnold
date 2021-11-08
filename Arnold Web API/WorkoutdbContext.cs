using System;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Arnold_Web_API.Models
{
    public class WorkoutdbContext : DbContext
    {
        public WorkoutdbContext()
        {
        }

        public WorkoutdbContext(DbContextOptions<WorkoutdbContext> options)
            : base(options)
        {
        }
        
        
        public DbSet<Exercise> Exercises { get; set; }
        public virtual DbSet<WorkoutRoutine> WorkoutRoutines { get; set; }
        public virtual DbSet<WorkoutRoutineHasExercise> WorkoutRoutineHasExercises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            modelBuilder.Entity<Exercise>(entity =>
            {
                entity.HasKey(e => e.Idexercise)
                    .HasName("PRIMARY");

                entity.ToTable("exercise");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Idexercise)
                    .HasColumnType("int(11)")
                    .HasColumnName("idexercise");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("category");

                entity.Property(e => e.Compound)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("compound");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<WorkoutRoutine>(entity =>
            {
                entity.HasKey(e => e.IdworkoutRoutine)
                    .HasName("PRIMARY");

                entity.ToTable("workout_routine");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.CreatorIdCreator, "fk_workout_routine_Creator1_idx");

                entity.Property(e => e.IdworkoutRoutine)
                    .HasColumnType("int(11)")
                    .HasColumnName("idworkout_routine");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreatorIdCreator)
                    .HasColumnType("int(11)")
                    .HasColumnName("Creator_idCreator");

                entity.Property(e => e.Difficulty)
                    .HasColumnType("int(11)")
                    .HasColumnName("difficulty");

                entity.Property(e => e.Duration)
                    .HasMaxLength(45)
                    .HasColumnName("duration");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<WorkoutRoutineHasExercise>(entity =>
            {
                entity.HasKey(e => new { e.WorkoutRoutineIdworkoutRoutine, e.ExerciseIdexercise })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("workout_routine_has_exercise");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.ExerciseIdexercise, "fk_workout_routine_has_exercise_exercise1_idx");

                entity.HasIndex(e => e.WorkoutRoutineIdworkoutRoutine, "fk_workout_routine_has_exercise_workout_routine1_idx");

                entity.Property(e => e.WorkoutRoutineIdworkoutRoutine)
                    .HasColumnType("int(11)")
                    .HasColumnName("workout_routine_idworkout_routine");

                entity.Property(e => e.ExerciseIdexercise)
                    .HasColumnType("int(11)")
                    .HasColumnName("exercise_idexercise");

                entity.Property(e => e.Repetitions)
                    .HasColumnType("int(11)")
                    .HasColumnName("repetitions");

                entity.Property(e => e.Sets)
                    .HasColumnType("int(11)")
                    .HasColumnName("sets");

                entity.HasOne(d => d.WorkoutRoutine)
                    .WithMany(p => p.WorkoutRoutineHasExercises)
                    .HasForeignKey(d => d.WorkoutRoutineIdworkoutRoutine)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_workout_routine_has_exercise_workout_routine1");
            });
        }
    }
}
