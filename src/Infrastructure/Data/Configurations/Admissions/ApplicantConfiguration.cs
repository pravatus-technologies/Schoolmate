using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schoolmate.Domain.Entities.ApplicantAggregate;
using Schoolmate.Domain.ValueObjects;

namespace Schoolmate.Infrastructure.Data.Configurations.Admissions;

public class ApplicantConfiguration : IEntityTypeConfiguration<Applicant>
{
    public void Configure(EntityTypeBuilder<Applicant> builder)
    {
        BuildApplicantTable(builder);
        ConfigureAddressTable(builder);
        ConfigureParentInfoTable(builder);
        ConfigureAcademicHistoryTable(builder);
        ConfigureApplicationStatusTable(builder);
    }

    private void BuildApplicantTable(EntityTypeBuilder<Applicant> builder)
    {
        builder.ToTable("Applicant");
        builder.Ignore(p => p.Age);

        builder.HasKey(p => p.Id)
            .HasAnnotation("SqlServer:Identity", 1);

        builder.Property(p => p.LearnerRefNumber)
            .HasColumnName("LearnerRefNum")
            .HasColumnType("nvarchar(20)");

        builder.Property(p => p.GivenNames)
            .HasColumnName("GivenNames")
            .HasColumnType("nvarchar(35)");

        builder.Property(p => p.MiddleName)
            .HasColumnName("MiddleName")
            .HasColumnType("nvarchar(35)");

        builder.Property(p => p.FamilyName)
            .HasColumnName("FamilyName")
            .HasColumnType("nvarchar(35)");

        builder.Property(p => p.Birthday)
            .HasColumnName("Birthday")
            .HasColumnType("date");

        builder.Property(p => p.Gender)
            .HasColumnName("Gender")
            .HasColumnType("nvarchar(10)")
            .HasConversion(item => item!.Name,
                value => Gender.FromName(value, true));

        builder.Property(p => p.Birthplace)
            .HasColumnName("Birthplace")
            .HasColumnType("nvarchar(35)");

        builder.Property(p => p.Nationality)
            .HasColumnName("Nationality")
            .HasColumnType("nvarchar(35)");

        builder.Property(p => p.Religion)
            .HasColumnName("Religion")
            .HasColumnType("nvarchar(35)");

        builder.Property(p => p.CivilStatus)
            .HasColumnName("CivilStatus")
            .HasColumnType("nvarchar(15)")
            .HasConversion(item => item!.Name,
                value => CivilStatus.FromName(value, true));
    }
    
    private void ConfigureAddressTable(EntityTypeBuilder<Applicant> builder)
        {
            builder.OwnsMany(p => p.AddressList, b => {
                b.ToTable("Address");

                b.HasKey(p => p.Id);
                
                b.WithOwner()
                    .HasForeignKey(p => p.ApplicantId)
                    .HasPrincipalKey(p => p.Id);

                b.Property(p => p.Line1)
                    .HasColumnType("nvarchar(50)");

                b.Property(p => p.Line2)
                    .HasColumnType("nvarchar(50)");

                b.Property(p => p.Baranggay)
                    .HasColumnType("nvarchar(35)");

                b.Property(p => p.Municipality)
                    .HasColumnType("nvarchar(35)");

                b.Property(p => p.Province)
                    .HasColumnType("nvarchar(35)");

                b.Property(p => p.PostalCode)
                    .HasColumnType("nvarchar(10)");

                b.Property(p => p.Country)
                    .HasColumnType("nvarchar(35)");

            });
        }

        private void ConfigureParentInfoTable(EntityTypeBuilder<Applicant> builder)
        {
            builder.OwnsMany(p => p.ParentList, b =>
            {
                b.ToTable("ParentInformation");

                b.HasKey(p => p.Id);
                
                b.WithOwner()
                    .HasForeignKey(p => p.ApplicantId)
                    .HasPrincipalKey(p => p.Id);

                b.Property(p => p.GivenNames)
                    .HasColumnType("nvarchar(35)");

                b.Property(p => p.MiddleName)
                    .HasColumnType("nvarchar(35)");

                b.Property(p => p.FamilyName)
                    .HasColumnType("nvarchar(35)");

                b.Property(p => p.ParentType)
                    .HasColumnType("nvarchar(15)")
                    .HasConversion(value => value!.Name,
                        value => ParentType.FromName(value, true));

                b.Property(p => p.HomeTelephone)
                    .HasColumnType("nvarchar(15)");

                b.Property(p => p.MobileTelephone)
                    .HasColumnType("nvarchar(15)");

                b.Property(p => p.EmailAddress)
                    .HasColumnType("nvarchar(100)");

                b.Property(p => p.Occupation)
                    .HasColumnType("nvarchar(75)");

                b.Property(p => p.EmployerName)
                    .HasColumnType("nvarchar(100)");

                b.Property(p => p.HighestEducationAttainment)
                    .HasColumnType("nvarchar(75)");

                b.Property(p => p.SchoolAttended)
                    .HasColumnType("nvarchar(100)");

            });
        }

        private void ConfigureAcademicHistoryTable(EntityTypeBuilder<Applicant> builder)
        {
            builder.OwnsMany(p => p.AcademicHistory, b =>
            {
                b.ToTable("AcademicHistory");
                b.HasKey(p => p.Id);

                b.WithOwner()
                    .HasForeignKey(p => p.ApplicantId)
                    .HasPrincipalKey(p => p.Id);

                b.Property(p => p.ProgramName)
                    .HasColumnName("ProgramName")
                    .HasColumnType("nvarchar(75)");

                b.Property(p => p.Institution)
                    .HasColumnName("Institution")
                    .HasColumnType("nvarchar(150)");

                b.Property(p => p.Address)
                    .HasColumnName("Address")
                    .HasColumnType("nvarchar(225)");

                b.Property(p => p.TelephoneNum)
                    .HasColumnName("TelephoneNum")
                    .HasColumnType("nvarchar(15)");

                b.Property(p => p.LastAcademicYearAttended)
                    .HasColumnName("LastAcademicYearAttended")
                    .HasColumnType("nvarchar(15)");

                b.Property(p => p.IsCompleted)
                    .HasColumnName("IsCompleted")
                    .HasColumnType("bit");
            });
        }

        private void ConfigureApplicationStatusTable(EntityTypeBuilder<Applicant> builder)
        {
            builder.OwnsMany(p => p.ApplicationStatuses, b =>
            {
                b.ToTable("ApplicationStatus");
                b.HasKey(p => p.Id);

                b.WithOwner()
                    .HasForeignKey(p => p.ApplicantId)
                    .HasPrincipalKey(p => p.Id);

                b.Property(p => p.ApplicationStatusType)
                    .HasColumnName("ApplicationStatusType")
                    .HasColumnType("nvarchar(20)")
                    .HasConversion(item => item.Name,
                        value => ApplicationStatusType.FromName(value, true));
            });
        }
}
