// <auto-generated />
using System;
using Leads.Api.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Leads.Api.Migrations
{
    [DbContext(typeof(LeadsDbContext))]
    partial class LeadsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Leads.Api.Core.Domain.LeadsRequestResponseDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RequestPayload")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RequestTimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("ResponsePayload")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ResponseTimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("WebMethodId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WebMethodId");

                    b.ToTable("TM_LogRequestsResponse");
                });

            modelBuilder.Entity("Leads.Api.Core.Domain.WebMethod", b =>
                {
                    b.Property<int>("WebMethodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WebMethodId");

                    b.ToTable("TR_WebMethod");
                });

            modelBuilder.Entity("Leads.Api.Core.Domain.LeadsRequestResponseDetail", b =>
                {
                    b.HasOne("Leads.Api.Core.Domain.WebMethod", "WebMethod")
                        .WithMany("LeadsRequestResponseDetails")
                        .HasForeignKey("WebMethodId")
                        .HasConstraintName("FK_WEBMETHOD_LEADSREQUESTRESPONSELOG")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WebMethod");
                });

            modelBuilder.Entity("Leads.Api.Core.Domain.WebMethod", b =>
                {
                    b.Navigation("LeadsRequestResponseDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
