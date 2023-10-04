﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopFuji.Migrations
{
    /// <inheritdoc />
    public partial class product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.CreateTable(
			   name: "Products",
			   columns: table => new
			   {
				   Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
				   Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
				   Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
				   Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
				   Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
				   Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
				   Size = table.Column<string>(type: "nvarchar(max)", nullable: false)
			   },
			   constraints: table =>
			   {
				   table.PrimaryKey("PK_Products", x => x.Id);
			   });

		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
