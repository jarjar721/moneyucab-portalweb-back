using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace moneyucab_portalweb_back.Migrations
{
    public partial class TraduccionTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SignupDate",
                table: "AspNetUsers",
                type: "DATE",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.CreateTable(
                name: "EstadoCivil",
                columns: table => new
                {
                    idEstadoCivil = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descripcion = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    codigo = table.Column<char>(type: "CHAR(1)", nullable: false),
                    estatus = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCivil", x => x.idEstadoCivil);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    idUsuario = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idTipoUsuario = table.Column<int>(type: "INT", nullable: false),
                    idTipoIdentificacion = table.Column<int>(type: "INT", nullable: false),
                    idEntity = table.Column<string>(type: "TEXT", nullable: false),
                    usuario = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    fecha_registro = table.Column<DateTime>(type: "DATE", nullable: false),
                    nro_identificacion = table.Column<int>(type: "INT", nullable: false),
                    email = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    telefono = table.Column<string>(type: "VARCHAR(12)", nullable: false),
                    direccion = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    estatus = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.idUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Entity",
                        column: x => x.idEntity,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comercio",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    razon_social = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    nombre_representante = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    apellido_representante = table.Column<string>(type: "VARCHAR(45)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comercio", x => x.idUsuario);
                    table.ForeignKey(
                        name: "FK_Comercio_Usuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    apellido = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    fecha_nacimiento = table.Column<DateTime>(type: "DATE", nullable: false),
                    idEstadoCivil = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.idUsuario);
                    table.ForeignKey(
                        name: "FK_Persona_EstadoCivil",
                        column: x => x.idEstadoCivil,
                        principalTable: "EstadoCivil",
                        principalColumn: "idEstadoCivil",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persona_Usuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comercio_idUsuario",
                table: "Comercio",
                column: "idUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persona_idEstadoCivil",
                table: "Persona",
                column: "idEstadoCivil");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_idUsuario",
                table: "Persona",
                column: "idUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_idEntity",
                table: "Usuario",
                column: "idEntity",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comercio");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "EstadoCivil");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SignupDate",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATE");
        }
    }
}
