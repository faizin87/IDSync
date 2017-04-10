using IDSync.Models;
using System.Data.Entity; 

namespace IDSync.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class Dal : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public DbSet<App> App { get; set; }
        public DbSet<AppSamAccountName> AppSamAccountName { get; set; }
        public DbSet<AppSchema> AppSchema { get; set; }
        public DbSet<AppSchemaIn> AppSchemaIn { get; set; }
        public DbSet<AppSchemaOut> AppSchemaOut { get; set; }
        public DbSet<AppSync> AppSync { get; set; }
        public DbSet<AppSyncOrder> AppSyncOrder { get; set; }
        public DbSet<AuthGroup> AuthGroup { get; set; }
        public DbSet<AuthLink> AuthLink { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<GroupSchema> GroupSchema { get; set; }
        public DbSet<Logs> Logs { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<TmpOrganizationUnit> TmpOrganizationUnit { get; set; }
        public DbSet<TmpPosition> TmpPosition { get; set; }
        public DbSet<Users> Users { get; set; } 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<App>().ToTable("App");
            modelBuilder.Entity<App>().HasKey(x => x.AppId);

            modelBuilder.Entity<AppSamAccountName>().ToTable("AppSamAccountName");
            modelBuilder.Entity<AppSamAccountName>().HasKey(x => x.AppSamAccountNameId);

            modelBuilder.Entity<AppSchema>().ToTable("AppSchema");
            modelBuilder.Entity<AppSchema>().HasKey(x => x.AppSchemaId);

            modelBuilder.Entity<AppSchemaIn>().ToTable("AppSchemaIn");
            modelBuilder.Entity<AppSchemaIn>().HasKey(x => x.AppSchemaInId);

            modelBuilder.Entity<AppSchemaOut>().ToTable("AppSchemaOut");
            modelBuilder.Entity<AppSchemaOut>().HasKey(x => x.AppSchemaOutId);

            modelBuilder.Entity<AppSync>().ToTable("AppSync");
            modelBuilder.Entity<AppSync>().HasKey(x => x.AppSyncId);

            modelBuilder.Entity<AppSyncOrder>().ToTable("AppSyncOrder");
            modelBuilder.Entity<AppSyncOrder>().HasKey(x => x.AppSyncOrderId);

            modelBuilder.Entity<AuthGroup>().ToTable("AuthGroup");
            modelBuilder.Entity<AuthGroup>().HasKey(x => x.AuthGroupId);

            modelBuilder.Entity<AuthLink>().ToTable("AuthLink");
            modelBuilder.Entity<AuthLink>().HasKey(x => x.AuthLinkId);

            modelBuilder.Entity<City>().ToTable("City");
            modelBuilder.Entity<City>().HasKey(x => x.CityId);

            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<Country>().HasKey(x => x.CountryId);

            modelBuilder.Entity<Groups>().ToTable("Groups");
            modelBuilder.Entity<Groups>().HasKey(x => x.GroupId);

            modelBuilder.Entity<GroupSchema>().ToTable("GroupSchema");
            modelBuilder.Entity<GroupSchema>().HasKey(x => x.GroupSchemaId);

            modelBuilder.Entity<Logs>().ToTable("Logs");
            modelBuilder.Entity<Logs>().HasKey(x => x.LogId);

            modelBuilder.Entity<Products>().ToTable("Products");
            modelBuilder.Entity<Products>().HasKey(x => x.ProductId);

            modelBuilder.Entity<Province>().ToTable("Province");
            modelBuilder.Entity<Province>().HasKey(x => x.ProvinceId);

            modelBuilder.Entity<TmpOrganizationUnit>().ToTable("TmpOrganizationUnit");
            modelBuilder.Entity<TmpOrganizationUnit>().HasKey(x => x.TmpOrganizationUnitId);   

            modelBuilder.Entity<TmpPosition>().ToTable("TmpPosition");
            modelBuilder.Entity<TmpPosition>().HasKey(x => x.TmpPositionId);

            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<Users>().HasKey(x => x.UserId);

        }
    }
}