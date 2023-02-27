using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RabbitMqCustomerAPI.Data;

namespace RabbitMqCustomerAPI.Migrations
{
	[DbContext(typeof(DbContextClass))]
	[Migration("20230227818181_First")]
	partial class First
	{
		protected override void BuildTargetModel(ModelBuilder modelBuilder)
		{
			modelBuilder
				.HasAnnotation("CustomerVersion", "1.0.1")
				.HasAnnotation("Relational:MaxIdentifierLength", 128);

			SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

			modelBuilder.Entity("RabbitMqCustomerAPI.Models.Customer", b =>
			{
				b.Property<int>("Id")
					.ValueGeneratedOnAdd()
					.HasColumnType("int");

				SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

				b.Property<string>("Name")
					.IsRequired()
					.HasColumnType("nvarchar(max)");

				b.HasKey("Id");

				b.ToTable("Customers");
			});
		}
	}
}
