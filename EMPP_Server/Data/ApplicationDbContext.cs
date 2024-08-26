using AutoMapper;
using DataAccess.ApplicationData;
using DataModels.ApplicationModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EMPP_Server.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<MainInfo> MainInfo { get; set; }
        public DbSet<WorkHistory> WorkHistory { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<InitialStage> InitialStages { get; set; }
        public DbSet<LanguageTest> LanguageTests { get; set; }
        public DbSet<LanguageData> LanguageData { get; set; }

        //internal Action<IMappingOperationOptions<object, void>> FindAsync(WorkHistoryDTO workHistory)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
