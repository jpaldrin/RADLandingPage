namespace DAL.Radio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Certificates",
                c => new
                    {
                        CertificateId = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                        Description = c.String(),
                        Number = c.String(),
                        AuthorizedBy = c.String(),
                        AuthorizedFrom = c.String(),
                        BeginDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CertificateId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        Lat = c.String(),
                        Log = c.String(),
                        LinkedIn = c.String(),
                        Twitter = c.String(),
                        Facebook = c.String(),
                        WhatsApp = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.ContractorProfiles",
                c => new
                    {
                        ContractorId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        ContactPerson = c.String(),
                        EIN = c.String(),
                        IsInsured = c.String(),
                        HasWebsite = c.String(),
                        IsContracted = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ContractorId);
            
            CreateTable(
                "dbo.ImgObjs",
                c => new
                    {
                        ImgObjId = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        FileContentType = c.String(),
                        ImageData = c.Binary(),
                        ContractorProfile_ContractorId = c.Int(),
                    })
                .PrimaryKey(t => t.ImgObjId)
                .ForeignKey("dbo.ContractorProfiles", t => t.ContractorProfile_ContractorId)
                .Index(t => t.ContractorProfile_ContractorId);
            
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        EmailId = c.Int(nullable: false, identity: true),
                        ToEmail = c.String(),
                        EMailBody = c.String(),
                        EmailCC = c.String(),
                        EmailBCC = c.String(),
                        UserId = c.String(),
                        SentDateTime = c.DateTime(nullable: false),
                        ReceivedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmailId);
            
            CreateTable(
                "dbo.LandingPages",
                c => new
                    {
                        LandingPageId = c.Int(nullable: false, identity: true),
                        One = c.String(),
                        Two = c.String(),
                        Three = c.String(),
                        Four = c.String(),
                        Five = c.String(),
                        Six = c.String(),
                        Seven = c.String(),
                        Eight = c.String(),
                        Nine = c.String(),
                        Ten = c.String(),
                        Eleven = c.String(),
                        Tweleve = c.String(),
                        Thirteen = c.String(),
                        Fourteen = c.String(),
                        Fifteen = c.String(),
                        Seventeen = c.String(),
                        Eighteen = c.String(),
                        Nineteen = c.String(),
                        Twenty = c.String(),
                        TwentyOne = c.String(),
                        TwentyTwo = c.String(),
                        TwentyThree = c.String(),
                        TwentyFour = c.String(),
                        TwentyFive = c.String(),
                        TwentySIx = c.String(),
                        TwentySeven = c.String(),
                        TwentyEight = c.String(),
                        TwentyNine = c.String(),
                        Thirty = c.String(),
                        ThirtyOne = c.String(),
                        ThirtyTwo = c.String(),
                        ThirtyThree = c.String(),
                        ThirtyFour = c.String(),
                        ThirtyFive = c.String(),
                        ThirtySix = c.String(),
                        ThirtySeven = c.String(),
                        ThirtyEight = c.String(),
                        ThirtyNine = c.String(),
                        Fourty = c.String(),
                        FourtyOne = c.String(),
                        fourtyTwo = c.String(),
                        FourtyThree = c.String(),
                        FourtyFour = c.String(),
                    })
                .PrimaryKey(t => t.LandingPageId);
            
            CreateTable(
                "dbo.SiteOwners",
                c => new
                    {
                        SiteOwnerId = c.Int(nullable: false, identity: true),
                        Company = c.String(),
                        EIN = c.String(),
                        IsInsured = c.String(),
                        IsLocked = c.Boolean(nullable: false),
                        IsContracted = c.Boolean(nullable: false),
                        Latitude = c.String(),
                        Longitude = c.String(),
                        ImgObj_ImgObjId = c.Int(),
                    })
                .PrimaryKey(t => t.SiteOwnerId)
                .ForeignKey("dbo.ImgObjs", t => t.ImgObj_ImgObjId)
                .Index(t => t.ImgObj_ImgObjId);
            
            CreateTable(
                "dbo.Sites",
                c => new
                    {
                        SiteId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category = c.String(),
                        AppNo = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Post = c.String(),
                        Status = c.String(),
                        Version = c.String(),
                        ProjectType = c.String(),
                        ApprovedBy = c.String(),
                        LastModified = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(),
                        SiteClass = c.String(),
                        SiteType = c.String(),
                        PlanYear = c.String(),
                        Market = c.String(),
                        Vendor = c.String(),
                        Latitude = c.String(),
                        Longitude = c.String(),
                        Region = c.String(),
                    })
                .PrimaryKey(t => t.SiteId);
            
            CreateTable(
                "dbo.RiggingPlans",
                c => new
                    {
                        RiggingPlanId = c.Int(nullable: false, identity: true),
                        RiggingPlanNotes = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RiggingPlanId);
            
            CreateTable(
                "dbo.GuestEmails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Name = c.String(),
                        Phone = c.String(),
                        Message = c.String(),
                        ReceivedDate = c.DateTime(nullable: false),
                        UserIpAddress = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectInformations",
                c => new
                    {
                        ProjectInformationId = c.Int(nullable: false, identity: true),
                        RiggingPlanNumber = c.String(),
                        CompletedBy = c.String(),
                        BUNumber = c.String(),
                        SiteAddress = c.String(),
                        RevisionNo = c.String(),
                        SiteName = c.String(),
                        Latitude = c.String(),
                        Longitude = c.String(),
                        AppNo = c.String(),
                        ProjectInormationDateTime = c.DateTime(nullable: false),
                        EORProjectNo = c.String(),
                    })
                .PrimaryKey(t => t.ProjectInformationId);
            
            CreateTable(
                "dbo.Employee_Certificates",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        CertificateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmployeeId, t.CertificateId })
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Certificates", t => t.CertificateId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.CertificateId);
            
            CreateTable(
                "dbo.Email_Attachments",
                c => new
                    {
                        EmailId = c.Int(nullable: false),
                        ImgObjId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmailId, t.ImgObjId })
                .ForeignKey("dbo.Emails", t => t.EmailId, cascadeDelete: true)
                .ForeignKey("dbo.ImgObjs", t => t.ImgObjId, cascadeDelete: true)
                .Index(t => t.EmailId)
                .Index(t => t.ImgObjId);
            
            CreateTable(
                "dbo.LandingPage_Attachments",
                c => new
                    {
                        LandingPageId = c.Int(nullable: false),
                        ImgObjId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LandingPageId, t.ImgObjId })
                .ForeignKey("dbo.LandingPages", t => t.LandingPageId, cascadeDelete: true)
                .ForeignKey("dbo.ImgObjs", t => t.ImgObjId, cascadeDelete: true)
                .Index(t => t.LandingPageId)
                .Index(t => t.ImgObjId);
            
            CreateTable(
                "dbo.Site_ImgObjs",
                c => new
                    {
                        SiteId = c.Int(nullable: false),
                        ImgObjId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SiteId, t.ImgObjId })
                .ForeignKey("dbo.Sites", t => t.SiteId, cascadeDelete: true)
                .ForeignKey("dbo.ImgObjs", t => t.ImgObjId, cascadeDelete: true)
                .Index(t => t.SiteId)
                .Index(t => t.ImgObjId);
            
            CreateTable(
                "dbo.Site_RiggingPlans",
                c => new
                    {
                        RiggingPlanId = c.Int(nullable: false),
                        SiteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RiggingPlanId, t.SiteId })
                .ForeignKey("dbo.Sites", t => t.RiggingPlanId, cascadeDelete: true)
                .ForeignKey("dbo.RiggingPlans", t => t.SiteId, cascadeDelete: true)
                .Index(t => t.RiggingPlanId)
                .Index(t => t.SiteId);
            
            CreateTable(
                "dbo.SiteOwner_Site",
                c => new
                    {
                        SiteOwnerId = c.Int(nullable: false),
                        SiteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SiteOwnerId, t.SiteId })
                .ForeignKey("dbo.SiteOwners", t => t.SiteOwnerId, cascadeDelete: true)
                .ForeignKey("dbo.Sites", t => t.SiteId, cascadeDelete: true)
                .Index(t => t.SiteOwnerId)
                .Index(t => t.SiteId);
            
            CreateTable(
                "dbo.ContractorProfiles_Sites",
                c => new
                    {
                        SiteId = c.Int(nullable: false),
                        ContractorProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SiteId, t.ContractorProfileId })
                .ForeignKey("dbo.ContractorProfiles", t => t.SiteId, cascadeDelete: true)
                .ForeignKey("dbo.Sites", t => t.ContractorProfileId, cascadeDelete: true)
                .Index(t => t.SiteId)
                .Index(t => t.ContractorProfileId);
            
            CreateTable(
                "dbo.ContractorProfiles_Employees",
                c => new
                    {
                        CertificateId = c.Int(nullable: false),
                        ImgObjId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CertificateId, t.ImgObjId })
                .ForeignKey("dbo.Employees", t => t.CertificateId, cascadeDelete: true)
                .ForeignKey("dbo.ContractorProfiles", t => t.ImgObjId, cascadeDelete: true)
                .Index(t => t.CertificateId)
                .Index(t => t.ImgObjId);
            
            CreateTable(
                "dbo.Employee_ImgObjs",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        ImgObjId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmployeeId, t.ImgObjId })
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.ImgObjs", t => t.ImgObjId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.ImgObjId);
            
            CreateTable(
                "dbo.Certificate_ImgObjs",
                c => new
                    {
                        CertificateId = c.Int(nullable: false),
                        ImgObjId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CertificateId, t.ImgObjId })
                .ForeignKey("dbo.Certificates", t => t.CertificateId, cascadeDelete: true)
                .ForeignKey("dbo.ImgObjs", t => t.ImgObjId, cascadeDelete: true)
                .Index(t => t.CertificateId)
                .Index(t => t.ImgObjId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Certificate_ImgObjs", "ImgObjId", "dbo.ImgObjs");
            DropForeignKey("dbo.Certificate_ImgObjs", "CertificateId", "dbo.Certificates");
            DropForeignKey("dbo.Employee_ImgObjs", "ImgObjId", "dbo.ImgObjs");
            DropForeignKey("dbo.Employee_ImgObjs", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.ContractorProfiles_Employees", "ImgObjId", "dbo.ContractorProfiles");
            DropForeignKey("dbo.ContractorProfiles_Employees", "CertificateId", "dbo.Employees");
            DropForeignKey("dbo.ContractorProfiles_Sites", "ContractorProfileId", "dbo.Sites");
            DropForeignKey("dbo.ContractorProfiles_Sites", "SiteId", "dbo.ContractorProfiles");
            DropForeignKey("dbo.ImgObjs", "ContractorProfile_ContractorId", "dbo.ContractorProfiles");
            DropForeignKey("dbo.SiteOwners", "ImgObj_ImgObjId", "dbo.ImgObjs");
            DropForeignKey("dbo.SiteOwner_Site", "SiteId", "dbo.Sites");
            DropForeignKey("dbo.SiteOwner_Site", "SiteOwnerId", "dbo.SiteOwners");
            DropForeignKey("dbo.Site_RiggingPlans", "SiteId", "dbo.RiggingPlans");
            DropForeignKey("dbo.Site_RiggingPlans", "RiggingPlanId", "dbo.Sites");
            DropForeignKey("dbo.Site_ImgObjs", "ImgObjId", "dbo.ImgObjs");
            DropForeignKey("dbo.Site_ImgObjs", "SiteId", "dbo.Sites");
            DropForeignKey("dbo.LandingPage_Attachments", "ImgObjId", "dbo.ImgObjs");
            DropForeignKey("dbo.LandingPage_Attachments", "LandingPageId", "dbo.LandingPages");
            DropForeignKey("dbo.Email_Attachments", "ImgObjId", "dbo.ImgObjs");
            DropForeignKey("dbo.Email_Attachments", "EmailId", "dbo.Emails");
            DropForeignKey("dbo.Employee_Certificates", "CertificateId", "dbo.Certificates");
            DropForeignKey("dbo.Employee_Certificates", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Certificate_ImgObjs", new[] { "ImgObjId" });
            DropIndex("dbo.Certificate_ImgObjs", new[] { "CertificateId" });
            DropIndex("dbo.Employee_ImgObjs", new[] { "ImgObjId" });
            DropIndex("dbo.Employee_ImgObjs", new[] { "EmployeeId" });
            DropIndex("dbo.ContractorProfiles_Employees", new[] { "ImgObjId" });
            DropIndex("dbo.ContractorProfiles_Employees", new[] { "CertificateId" });
            DropIndex("dbo.ContractorProfiles_Sites", new[] { "ContractorProfileId" });
            DropIndex("dbo.ContractorProfiles_Sites", new[] { "SiteId" });
            DropIndex("dbo.SiteOwner_Site", new[] { "SiteId" });
            DropIndex("dbo.SiteOwner_Site", new[] { "SiteOwnerId" });
            DropIndex("dbo.Site_RiggingPlans", new[] { "SiteId" });
            DropIndex("dbo.Site_RiggingPlans", new[] { "RiggingPlanId" });
            DropIndex("dbo.Site_ImgObjs", new[] { "ImgObjId" });
            DropIndex("dbo.Site_ImgObjs", new[] { "SiteId" });
            DropIndex("dbo.LandingPage_Attachments", new[] { "ImgObjId" });
            DropIndex("dbo.LandingPage_Attachments", new[] { "LandingPageId" });
            DropIndex("dbo.Email_Attachments", new[] { "ImgObjId" });
            DropIndex("dbo.Email_Attachments", new[] { "EmailId" });
            DropIndex("dbo.Employee_Certificates", new[] { "CertificateId" });
            DropIndex("dbo.Employee_Certificates", new[] { "EmployeeId" });
            DropIndex("dbo.SiteOwners", new[] { "ImgObj_ImgObjId" });
            DropIndex("dbo.ImgObjs", new[] { "ContractorProfile_ContractorId" });
            DropTable("dbo.Certificate_ImgObjs");
            DropTable("dbo.Employee_ImgObjs");
            DropTable("dbo.ContractorProfiles_Employees");
            DropTable("dbo.ContractorProfiles_Sites");
            DropTable("dbo.SiteOwner_Site");
            DropTable("dbo.Site_RiggingPlans");
            DropTable("dbo.Site_ImgObjs");
            DropTable("dbo.LandingPage_Attachments");
            DropTable("dbo.Email_Attachments");
            DropTable("dbo.Employee_Certificates");
            DropTable("dbo.ProjectInformations");
            DropTable("dbo.GuestEmails");
            DropTable("dbo.RiggingPlans");
            DropTable("dbo.Sites");
            DropTable("dbo.SiteOwners");
            DropTable("dbo.LandingPages");
            DropTable("dbo.Emails");
            DropTable("dbo.ImgObjs");
            DropTable("dbo.ContractorProfiles");
            DropTable("dbo.Employees");
            DropTable("dbo.Certificates");
        }
    }
}
