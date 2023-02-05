using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TeamManagement.Models
{
    public partial class FPTUProjectContext : DbContext
    {
        public FPTUProjectContext()
        {
        }

        public FPTUProjectContext(DbContextOptions<FPTUProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseTeam> CourseTeams { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<TeacherTopic> TeacherTopics { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<TeamTeacher> TeamTeachers { get; set; }
        public virtual DbSet<TeamTopic> TeamTopics { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server =(db-project-manager.c4izale5z03d.ap-southeast-1.rds.amazonaws.com,1433); database = DB=DBProjectManagement;uid=admin;pwd=12345678;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.CourseId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SemId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SubId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TeacherId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Sem)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.SemId)
                    .HasConstraintName("FK__Course__SemId__48CFD27E");

                entity.HasOne(d => d.Sub)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.SubId)
                    .HasConstraintName("FK__Course__SubId__49C3F6B7");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_Teacher");
            });

            modelBuilder.Entity<CourseTeam>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Course_Team");

                entity.Property(e => e.CourseId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TeamId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany()
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_Course_Team_Courses");

                entity.HasOne(d => d.Team)
                    .WithMany()
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_Course_Team_Teams");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptId)
                    .HasName("PK__Departme__014881AE68374298");

                entity.ToTable("Department");

                entity.Property(e => e.DeptId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DeptName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Participant>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Participant");

                entity.Property(e => e.CourseId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.InCourse)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StuId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TeamId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany()
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_Participants_Courses");

                entity.HasOne(d => d.Stu)
                    .WithMany()
                    .HasForeignKey(d => d.StuId)
                    .HasConstraintName("FK_Participants_Students");

                entity.HasOne(d => d.Team)
                    .WithMany()
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_Participants_Teams");
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.HasKey(e => e.SemId)
                    .HasName("PK__Semester__16D6C7AAA45E5424");

                entity.ToTable("Semester");

                entity.Property(e => e.SemId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SemName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StuId)
                    .HasName("PK__Student__6CDFAB95779C6DD2");

                entity.ToTable("Student");

                entity.Property(e => e.StuId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.StuEmail).HasMaxLength(50);

                entity.Property(e => e.StuGender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StuName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StuPhone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.SubId)
                    .HasName("PK__Subject__4D9BB84A879379CB");

                entity.ToTable("Subject");

                entity.Property(e => e.SubId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DeptId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SubName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.DeptId)
                    .HasConstraintName("FK__Subject__DeptId__5070F446");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher");

                entity.Property(e => e.TeacherId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TeacherEmail).HasMaxLength(50);

                entity.Property(e => e.TeacherName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TeacherPhone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TeacherTopic>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Teacher_Topic");

                entity.Property(e => e.TeacherId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TopicId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Teacher)
                    .WithMany()
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_Teacher_Topic_Teachers");

                entity.HasOne(d => d.Topic)
                    .WithMany()
                    .HasForeignKey(d => d.TopicId)
                    .HasConstraintName("FK_Teacher_Topic_Topics");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("Team");

                entity.Property(e => e.TeamId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TeamName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TeamTeacher>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Team_Teacher");

                entity.Property(e => e.TeacherId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TeamId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Teacher)
                    .WithMany()
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_Team_Teacher_Teachers");

                entity.HasOne(d => d.Team)
                    .WithMany()
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_Team_Teacher_Teams");
            });

            modelBuilder.Entity<TeamTopic>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Team_Topic");

                entity.Property(e => e.TeamId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TopicId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Team)
                    .WithMany()
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_Team_Topic_Teams");

                entity.HasOne(d => d.Topic)
                    .WithMany()
                    .HasForeignKey(d => d.TopicId)
                    .HasConstraintName("FK_Team_Topic_Topics");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("Topic");

                entity.Property(e => e.TopicId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CourseId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TopicName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Topics)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__Topic__CourseId__571DF1D5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
