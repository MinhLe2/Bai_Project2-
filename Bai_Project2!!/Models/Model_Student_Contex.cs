namespace Bai_Project2__.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model_Student_Contex : DbContext
    {
        public Model_Student_Contex()
            : base("name=Model_Student_Contex")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public System.Data.Entity.DbSet<Bai_Project2__.Models.Subject> Subjects { get; set; }

        public System.Data.Entity.DbSet<Bai_Project2__.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<Bai_Project2__.Models.Exam> Exams { get; set; }
    }
}
