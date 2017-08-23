namespace Tool.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CheckTestModel : DbContext
    {
        public CheckTestModel()
            : base("name=CheckTestModel")
        {
        }

        public virtual DbSet<CheckResult_1000_ND_5> CheckResult_1000_ND_5 { get; set; }
        public virtual DbSet<CheckResult_1000_WF_5> CheckResult_1000_WF_5 { get; set; }
        public virtual DbSet<CheckResult_5000_ND> CheckResult_5000_ND { get; set; }
        public virtual DbSet<CheckResult_5000_WF> CheckResult_5000_WF { get; set; }
        public virtual DbSet<CheckResult_Problem_ND> CheckResult_Problem_ND { get; set; }
        public virtual DbSet<CheckResult_Problem_WF> CheckResult_Problem_WF { get; set; }
        public virtual DbSet<CheckText_1000> CheckText_1000 { get; set; }
        public virtual DbSet<CheckText_5000> CheckText_5000 { get; set; }
        public virtual DbSet<CheckText_Problem> CheckText_Problem { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CheckResult_1000_ND_5>()
                .Property(e => e.Json)
                .IsUnicode(false);

            modelBuilder.Entity<CheckResult_1000_WF_5>()
                .Property(e => e.Json)
                .IsUnicode(false);

            modelBuilder.Entity<CheckResult_5000_ND>()
               .Property(e => e.Json)
               .IsUnicode(false);

            modelBuilder.Entity<CheckResult_5000_WF>()
               .Property(e => e.Json)
               .IsUnicode(false);

            modelBuilder.Entity<CheckResult_Problem_ND>()
               .Property(e => e.Json)
               .IsUnicode(false);

            modelBuilder.Entity<CheckResult_Problem_WF>()
               .Property(e => e.Json)
               .IsUnicode(false);

            modelBuilder.Entity<CheckText_1000>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<CheckText_5000>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<CheckText_Problem>()
                .Property(e => e.Content)
                .IsUnicode(false);
        }
    }
}
