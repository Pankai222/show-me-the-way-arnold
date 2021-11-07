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

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Creator> Creators { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseHasMuscle> ExerciseHasMuscles { get; set; }
        public DbSet<ExerciseHasWorkoutEquipment> ExerciseHasWorkoutEquipments { get; set; }
        public DbSet<ExerciseVideo> ExerciseVideos { get; set; }
        public DbSet<Muscle> Muscles { get; set; }
        public DbSet<WorkoutEquipment> WorkoutEquipments { get; set; }
        public DbSet<WorkoutOverview> WorkoutOverviews { get; set; }
        public virtual DbSet<WorkoutRoutine> WorkoutRoutines { get; set; }
        public virtual DbSet<WorkoutRoutineHasExercise> WorkoutRoutineHasExercises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => new { e.IdContact, e.CreatorIdCreator })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("contact");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.CreatorIdCreator, "fk_Contact_Creator1_idx");

                entity.Property(e => e.IdContact)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idContact");

                entity.Property(e => e.CreatorIdCreator)
                    .HasColumnType("int(11)")
                    .HasColumnName("Creator_idCreator");

                entity.Property(e => e.Emailaddress).HasMaxLength(45);

                entity.Property(e => e.Phonenumber).HasMaxLength(45);

                entity.HasOne(d => d.CreatorIdCreatorNavigation)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.CreatorIdCreator)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Contact_Creator1");
            });

            modelBuilder.Entity<Creator>(entity =>
            {
                entity.HasKey(e => e.IdCreator)
                    .HasName("PRIMARY");

                entity.ToTable("creator");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.IdCreator)
                    .HasColumnType("int(11)")
                    .HasColumnName("idCreator");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(45)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(45)
                    .HasColumnName("lastname");
            });

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

            modelBuilder.Entity<ExerciseHasMuscle>(entity =>
            {
                entity.HasKey(e => new { e.ExerciseIdexercise, e.MuscleIdmuscle })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("exercise_has_muscle");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.ExerciseIdexercise, "fk_exercise_has_muscle_exercise_idx");

                entity.HasIndex(e => e.MuscleIdmuscle, "fk_exercise_has_muscle_muscle1_idx");

                entity.Property(e => e.ExerciseIdexercise)
                    .HasColumnType("int(11)")
                    .HasColumnName("exercise_idexercise");

                entity.Property(e => e.MuscleIdmuscle)
                    .HasColumnType("int(11)")
                    .HasColumnName("muscle_idmuscle");

                entity.HasOne(d => d.ExerciseIdexerciseNavigation)
                    .WithMany(p => p.ExerciseHasMuscles)
                    .HasForeignKey(d => d.ExerciseIdexercise)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_exercise_has_muscle_exercise");

                entity.HasOne(d => d.MuscleIdmuscleNavigation)
                    .WithMany(p => p.ExerciseHasMuscles)
                    .HasForeignKey(d => d.MuscleIdmuscle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_exercise_has_muscle_muscle1");
            });

            modelBuilder.Entity<ExerciseHasWorkoutEquipment>(entity =>
            {
                entity.HasKey(e => new { e.WorkoutEquipmentIdworkoutEquipment, e.ExerciseIdexercise })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("exercise_has_workout_equipment");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.ExerciseIdexercise, "fk_exercise_has_workout_equipment_exercise1_idx");

                entity.Property(e => e.WorkoutEquipmentIdworkoutEquipment)
                    .HasColumnType("int(11)")
                    .HasColumnName("workout_equipment_idworkout_equipment");

                entity.Property(e => e.ExerciseIdexercise)
                    .HasColumnType("int(11)")
                    .HasColumnName("exercise_idexercise");

                entity.HasOne(d => d.ExerciseIdexerciseNavigation)
                    .WithMany(p => p.ExerciseHasWorkoutEquipments)
                    .HasForeignKey(d => d.ExerciseIdexercise)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_exercise_has_workout_equipment_exercise1");

                entity.HasOne(d => d.WorkoutEquipmentIdworkoutEquipmentNavigation)
                    .WithMany(p => p.ExerciseHasWorkoutEquipments)
                    .HasForeignKey(d => d.WorkoutEquipmentIdworkoutEquipment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_exercise_has_workout_equipment_workout_equipment2");
            });

            modelBuilder.Entity<ExerciseVideo>(entity =>
            {
                entity.HasKey(e => e.IdexerciseVideos)
                    .HasName("PRIMARY");

                entity.ToTable("exercise_videos");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.ExerciseIdexercise, "fk_exercise_videos_exercise1_idx");

                entity.Property(e => e.IdexerciseVideos)
                    .HasColumnType("int(11)")
                    .HasColumnName("idexercise_videos");

                entity.Property(e => e.ExerciseIdexercise)
                    .HasColumnType("int(11)")
                    .HasColumnName("exercise_idexercise");

                entity.Property(e => e.Video)
                    .HasMaxLength(100)
                    .HasColumnName("video");

                entity.HasOne(d => d.ExerciseIdexerciseNavigation)
                    .WithMany(p => p.ExerciseVideos)
                    .HasForeignKey(d => d.ExerciseIdexercise)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_exercise_videos_exercise1");
            });

            modelBuilder.Entity<Muscle>(entity =>
            {
                entity.HasKey(e => e.Idmuscle)
                    .HasName("PRIMARY");

                entity.ToTable("muscle");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Idmuscle)
                    .HasColumnType("int(11)")
                    .HasColumnName("idmuscle");

                entity.Property(e => e.Bodypart)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("bodypart");

                entity.Property(e => e.Musclegroup)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("musclegroup");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<WorkoutEquipment>(entity =>
            {
                entity.HasKey(e => e.IdworkoutEquipment)
                    .HasName("PRIMARY");

                entity.ToTable("workout_equipment");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.IdworkoutEquipment)
                    .HasColumnType("int(11)")
                    .HasColumnName("idworkout_equipment");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<WorkoutOverview>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("workout_overview");

                entity.Property(e => e.CreatorName)
                    .HasMaxLength(91)
                    .HasColumnName("creator_name")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Difficulty)
                    .HasColumnType("int(11)")
                    .HasColumnName("difficulty");

                entity.Property(e => e.Duration)
                    .HasMaxLength(45)
                    .HasColumnName("duration")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Exercise)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("exercise")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.WorkoutName)
                    .HasMaxLength(45)
                    .HasColumnName("workout_name")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
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

                entity.HasOne(d => d.CreatorIdCreatorNavigation)
                    .WithMany(p => p.WorkoutRoutines)
                    .HasForeignKey(d => d.CreatorIdCreator)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_workout_routine_Creator1");
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

                entity.HasOne(d => d.ExerciseIdexerciseNavigation)
                    .WithMany(p => p.WorkoutRoutineHasExercises)
                    .HasForeignKey(d => d.ExerciseIdexercise)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_workout_routine_has_exercise_exercise1");

                entity.HasOne(d => d.WorkoutRoutineIdworkoutRoutineNavigation)
                    .WithMany(p => p.WorkoutRoutineHasExercises)
                    .HasForeignKey(d => d.WorkoutRoutineIdworkoutRoutine)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_workout_routine_has_exercise_workout_routine1");
            });
        }
    }
}
