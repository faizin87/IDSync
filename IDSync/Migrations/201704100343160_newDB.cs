namespace IDSync.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.App",
                c => new
                    {
                        AppId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        DbType = c.String(),
                        Server = c.String(),
                        SID = c.String(),
                        Port = c.String(),
                        DbName = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        IsReadOnly = c.String(),
                    })
                .PrimaryKey(t => t.AppId);
            
            CreateTable(
                "dbo.AppSchema",
                c => new
                    {
                        AppSchemaId = c.String(nullable: false, maxLength: 128),
                        AppId = c.String(maxLength: 128),
                        Type = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.AppSchemaId)
                .ForeignKey("dbo.App", t => t.AppId)
                .Index(t => t.AppId);
            
            CreateTable(
                "dbo.AppSamAccountName",
                c => new
                    {
                        AppSamAccountNameId = c.String(nullable: false, maxLength: 128),
                        AppSchemaSchemaId = c.String(),
                        RuleIn = c.String(),
                        TypeIn = c.String(),
                        NumIn = c.String(),
                        RuleOut = c.String(),
                        TypeOut = c.String(),
                        NumOut = c.String(),
                        AppSchema_AppSchemaId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AppSamAccountNameId)
                .ForeignKey("dbo.AppSchema", t => t.AppSchema_AppSchemaId)
                .Index(t => t.AppSchema_AppSchemaId);
            
            CreateTable(
                "dbo.AppSchemaIn",
                c => new
                    {
                        AppSchemaInId = c.String(nullable: false, maxLength: 128),
                        AppSchemaId = c.String(maxLength: 128),
                        QueryIn = c.String(),
                        SchemaIn = c.String(),
                        DataType = c.String(),
                    })
                .PrimaryKey(t => t.AppSchemaInId)
                .ForeignKey("dbo.AppSchema", t => t.AppSchemaId)
                .Index(t => t.AppSchemaId);
            
            CreateTable(
                "dbo.AppSchemaOut",
                c => new
                    {
                        AppSchemaOutId = c.String(nullable: false, maxLength: 128),
                        AppSchemaId = c.String(maxLength: 128),
                        TableTarget = c.String(),
                        SchemaOut = c.String(),
                        DataType = c.String(),
                    })
                .PrimaryKey(t => t.AppSchemaOutId)
                .ForeignKey("dbo.AppSchema", t => t.AppSchemaId)
                .Index(t => t.AppSchemaId);
            
            CreateTable(
                "dbo.AppSync",
                c => new
                    {
                        AppSyncId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.AppSyncId);
            
            CreateTable(
                "dbo.AppSyncOrder",
                c => new
                    {
                        AppSyncOrderId = c.String(nullable: false, maxLength: 128),
                        AppSyncId = c.String(maxLength: 128),
                        Time = c.Time(precision: 7),
                        Order = c.String(),
                        IsEnable = c.String(),
                        OrganizationUnit = c.String(),
                        IsEnableExchange = c.String(),
                        IsEnableSkype = c.String(),
                        IsEnableSharepoint = c.String(),
                    })
                .PrimaryKey(t => t.AppSyncOrderId)
                .ForeignKey("dbo.AppSync", t => t.AppSyncId)
                .Index(t => t.AppSyncId);
            
            CreateTable(
                "dbo.AuthGroup",
                c => new
                    {
                        AuthGroupId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        AuthLinkId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AuthGroupId)
                .ForeignKey("dbo.AuthLink", t => t.AuthLinkId)
                .Index(t => t.AuthLinkId);
            
            CreateTable(
                "dbo.AuthLink",
                c => new
                    {
                        AuthLinkId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Link = c.String(),
                    })
                .PrimaryKey(t => t.AuthLinkId);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        CityId = c.String(nullable: false, maxLength: 128),
                        ProvinceId = c.String(maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CityId)
                .ForeignKey("dbo.Province", t => t.ProvinceId)
                .Index(t => t.ProvinceId);
            
            CreateTable(
                "dbo.Province",
                c => new
                    {
                        ProvinceId = c.String(nullable: false, maxLength: 128),
                        CountryId = c.String(maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ProvinceId)
                .ForeignKey("dbo.Country", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        CountryId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.String(nullable: false, maxLength: 128),
                        SamAccountName = c.String(),
                        UserPrincipalName = c.String(),
                        Name = c.String(),
                        DistinguishedName = c.String(),
                        GroupCategory = c.String(),
                        GroupScope = c.String(),
                        ObjectClass = c.String(),
                        ObjectGUID = c.String(),
                        SID = c.String(),
                        Info = c.String(),
                        Description = c.String(),
                        Email = c.String(),
                        Member = c.String(),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.GroupSchema",
                c => new
                    {
                        GroupSchemaId = c.String(nullable: false, maxLength: 128),
                        GroupName = c.String(),
                        JobTitle = c.String(),
                        Department = c.String(),
                        Country = c.String(),
                        Province = c.String(),
                        City = c.String(),
                        OrganizationUnit = c.String(),
                        Time = c.Time(precision: 7),
                        IsEnable = c.String(),
                    })
                .PrimaryKey(t => t.GroupSchemaId);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        LogId = c.String(nullable: false, maxLength: 128),
                        Type = c.String(),
                        Date = c.DateTime(),
                        SamAccountName = c.String(),
                        Description = c.String(),
                        Sync = c.String(),
                        ReadBy = c.String(),
                    })
                .PrimaryKey(t => t.LogId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        WebEndPoint = c.String(),
                        Photo = c.String(),
                        isPublish = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.TmpOrganizationUnit",
                c => new
                    {
                        TmpOrganizationUnitId = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        ShortName = c.String(),
                    })
                .PrimaryKey(t => t.TmpOrganizationUnitId);
            
            CreateTable(
                "dbo.TmpPosition",
                c => new
                    {
                        TmpPositionId = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        ShortName = c.String(),
                    })
                .PrimaryKey(t => t.TmpPositionId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LastLogon = c.DateTime(),
                        WhenCreated = c.DateTime(),
                        WhenChanged = c.DateTime(),
                        MsExchHomeServerName = c.String(),
                        PrimaryUserAddress = c.String(),
                        SIPAddress = c.String(),
                        SIPServer = c.String(),
                        Country = c.String(nullable: false, maxLength: 3),
                        Notes = c.String(nullable: false, maxLength: 1024),
                        EmployeeID = c.String(nullable: false, maxLength: 16),
                        Company = c.String(nullable: false, maxLength: 64),
                        SamAccountName = c.String(nullable: false, maxLength: 256),
                        FirstName = c.String(nullable: false, maxLength: 64),
                        LastName = c.String(nullable: false, maxLength: 64),
                        Office = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                        Street = c.String(nullable: false, maxLength: 1024),
                        PostalCode = c.String(nullable: false, maxLength: 40),
                        Province = c.String(nullable: false, maxLength: 128),
                        City = c.String(nullable: false, maxLength: 128),
                        Website = c.String(nullable: false, maxLength: 2048),
                        Telephone = c.String(nullable: false, maxLength: 64),
                        JobTitle = c.String(nullable: false, maxLength: 64),
                        DisplayName = c.String(nullable: false, maxLength: 256),
                        Department = c.String(nullable: false, maxLength: 64),
                        Manager = c.String(),
                        EmailAddress = c.String(nullable: false, maxLength: 256),
                        UserPrincipalName = c.String(),
                        Name = c.String(),
                        DistinguishedName = c.String(),
                        IsEnableSkype = c.Short(nullable: false),
                        IsEnableExchange = c.Short(nullable: false),
                        IsEnableSharepoint = c.Short(nullable: false),
                        SharepointURL = c.String(),
                        IsEnable = c.Boolean(nullable: false),
                        MemberOf = c.String(),
                        ExtensionAttribute1 = c.String(),
                        ExtensionAttribute2 = c.String(),
                        ExtensionAttribute3 = c.String(),
                        ExtensionAttribute4 = c.String(),
                        ExtensionAttribute5 = c.String(),
                        ExtensionAttribute6 = c.String(),
                        ExtensionAttribute7 = c.String(),
                        ExtensionAttribute8 = c.String(),
                        ExtensionAttribute9 = c.String(),
                        ExtensionAttribute10 = c.String(),
                        ExtensionAttribute11 = c.String(),
                        ExtensionAttribute12 = c.String(),
                        ExtensionAttribute13 = c.String(),
                        ExtensionAttribute14 = c.String(),
                        ExtensionAttribute15 = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Province", "CountryId", "dbo.Country");
            DropForeignKey("dbo.City", "ProvinceId", "dbo.Province");
            DropForeignKey("dbo.AuthGroup", "AuthLinkId", "dbo.AuthLink");
            DropForeignKey("dbo.AppSyncOrder", "AppSyncId", "dbo.AppSync");
            DropForeignKey("dbo.AppSchemaOut", "AppSchemaId", "dbo.AppSchema");
            DropForeignKey("dbo.AppSchemaIn", "AppSchemaId", "dbo.AppSchema");
            DropForeignKey("dbo.AppSamAccountName", "AppSchema_AppSchemaId", "dbo.AppSchema");
            DropForeignKey("dbo.AppSchema", "AppId", "dbo.App");
            DropIndex("dbo.Province", new[] { "CountryId" });
            DropIndex("dbo.City", new[] { "ProvinceId" });
            DropIndex("dbo.AuthGroup", new[] { "AuthLinkId" });
            DropIndex("dbo.AppSyncOrder", new[] { "AppSyncId" });
            DropIndex("dbo.AppSchemaOut", new[] { "AppSchemaId" });
            DropIndex("dbo.AppSchemaIn", new[] { "AppSchemaId" });
            DropIndex("dbo.AppSamAccountName", new[] { "AppSchema_AppSchemaId" });
            DropIndex("dbo.AppSchema", new[] { "AppId" });
            DropTable("dbo.Users");
            DropTable("dbo.TmpPosition");
            DropTable("dbo.TmpOrganizationUnit");
            DropTable("dbo.Products");
            DropTable("dbo.Logs");
            DropTable("dbo.GroupSchema");
            DropTable("dbo.Groups");
            DropTable("dbo.Country");
            DropTable("dbo.Province");
            DropTable("dbo.City");
            DropTable("dbo.AuthLink");
            DropTable("dbo.AuthGroup");
            DropTable("dbo.AppSyncOrder");
            DropTable("dbo.AppSync");
            DropTable("dbo.AppSchemaOut");
            DropTable("dbo.AppSchemaIn");
            DropTable("dbo.AppSamAccountName");
            DropTable("dbo.AppSchema");
            DropTable("dbo.App");
        }
    }
}
