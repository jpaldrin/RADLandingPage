using DAL.Radio.Model;
using System.Data.Entity;

namespace DAL.Radio.Context
{
    public partial class RadioDbContext : DbContext
    {
        public RadioDbContext()
            : base("name=RadioDbContext")
        {
            Database.SetInitializer
           (new DropCreateDatabaseIfModelChanges<RadioDbContext>());
        }

        public virtual DbSet<ContractorProfile> ContractorProfiles { get; set; }
        public virtual DbSet<Site> Sites { get; set; }
        public virtual DbSet<ImgObj> ImgObjs { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Certificates> Certificate { get; set; }
        public virtual DbSet<SiteOwner> SiteOwners { get; set; }
        public virtual DbSet<RiggingPlan> RiggingPlans { get; set; }
        public virtual DbSet<ProjectInformation> ProjectInformations { get; set; }
        public virtual DbSet<GuestEmail> GuestEmails { get; set; }
        public virtual DbSet<Email> Emails { get; set; }
        public virtual DbSet<LandingPage> LandingPages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Site>()
                .HasMany(i => i.ImgObjs)
                .WithMany(i => i.Sites)
                .Map(i =>
                {
                    i.MapLeftKey("SiteId");
                    i.MapRightKey("ImgObjId");
                    i.ToTable("Site_ImgObjs");
                });

            modelBuilder.Entity<ContractorProfile>()
               .HasMany(i => i.Sites)
               .WithMany(i => i.ContractorProfiles)
               .Map(i =>
               {
                   i.MapLeftKey("SiteId");
                   i.MapRightKey("ContractorProfileId");
                   i.ToTable("ContractorProfiles_Sites");
               });

            modelBuilder.Entity<Employee>()
                .HasMany(i => i.Certificates)
                .WithMany(i => i.Employees)
                .Map(i =>
                {
                    i.MapLeftKey("EmployeeId");
                    i.MapRightKey("CertificateId");
                    i.ToTable("Employee_Certificates");
                });

            modelBuilder.Entity<Employee>()
                .HasMany(i => i.ImgObjs)
                .WithMany(i => i.Employees)
                .Map(i =>
                {
                    i.MapLeftKey("EmployeeId");
                    i.MapRightKey("ImgObjId");
                    i.ToTable("Employee_ImgObjs");
                });

            modelBuilder.Entity<Certificates>()
               .HasMany(i => i.ImgObjs)
               .WithMany(i => i.Certificate)
               .Map(i =>
               {
                   i.MapLeftKey("CertificateId");
                   i.MapRightKey("ImgObjId");
                   i.ToTable("Certificate_ImgObjs");
               });

            modelBuilder.Entity<SiteOwner>()
              .HasMany(i => i.Sites)
              .WithMany(i => i.SiteOwners)
              .Map(i =>
              {
                  i.MapLeftKey("SiteOwnerId");
                  i.MapRightKey("SiteId");
                  i.ToTable("SiteOwner_Site");
              });

            modelBuilder.Entity<Employee>()
            .HasMany(i => i.ContractorProfiles)
            .WithMany(i => i.Employees)
            .Map(i =>
            {
                i.MapLeftKey("CertificateId");
                i.MapRightKey("ImgObjId");
                i.ToTable("ContractorProfiles_Employees");
            });

            modelBuilder.Entity<Site>()
           .HasMany(i => i.RiggingPlans)
           .WithMany(i => i.Sites)
           .Map(i =>
           {
               i.MapLeftKey("RiggingPlanId");
               i.MapRightKey("SiteId");
               i.ToTable("Site_RiggingPlans");
           });

            modelBuilder.Entity<Email>()
          .HasMany(i => i.ImgObjs)
          .WithMany(i => i.Emails)
          .Map(i =>
          {
              i.MapLeftKey("EmailId");
              i.MapRightKey("ImgObjId");
              i.ToTable("Email_Attachments");
          });

            modelBuilder.Entity<LandingPage>()
       .HasMany(i => i.ImgObjs)
       .WithMany(i => i.LandingPages)
       .Map(i =>
       {
           i.MapLeftKey("LandingPageId");
           i.MapRightKey("ImgObjId");
           i.ToTable("LandingPage_Attachments");
       });
        }
    }
}
