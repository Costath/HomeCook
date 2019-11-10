using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Assignment1.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Recipes_RecipeID",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_RecipeID",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "RecipeID",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasurement",
                table: "Ingredients");

            migrationBuilder.CreateTable(
                name: "Recipe_Ingredient",
                columns: table => new
                {
                    IngredientID = table.Column<int>(nullable: false),
                    RecipeID = table.Column<int>(nullable: false),
                    Quantity = table.Column<float>(nullable: true),
                    UnitOfMeasurement = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe_Ingredient", x => new { x.IngredientID, x.RecipeID });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipe_Ingredient");

            migrationBuilder.AddColumn<float>(
                name: "Quantity",
                table: "Ingredients",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "RecipeID",
                table: "Ingredients",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitOfMeasurement",
                table: "Ingredients",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeID",
                table: "Ingredients",
                column: "RecipeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Recipes_RecipeID",
                table: "Ingredients",
                column: "RecipeID",
                principalTable: "Recipes",
                principalColumn: "RecipeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
