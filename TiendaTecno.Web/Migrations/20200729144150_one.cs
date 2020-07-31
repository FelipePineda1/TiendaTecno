using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TiendaTecno.Web.Migrations
{
    public partial class one : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Especificaciones");

            migrationBuilder.DropTable(
                name: "Almacenamientos");

            migrationBuilder.DropTable(
                name: "MemoriasRam");

            migrationBuilder.DropTable(
                name: "Pantallas");

            migrationBuilder.DropTable(
                name: "Procesadores");

            migrationBuilder.DropTable(
                name: "SistemasOperativos");

            migrationBuilder.DropTable(
                name: "TiposPantallas");

            migrationBuilder.RenameColumn(
                name: "IdMarca",
                table: "Marcas",
                newName: "MarcaID");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Marcas",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MarcaID",
                table: "Marcas",
                newName: "IdMarca");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Marcas",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.CreateTable(
                name: "Almacenamientos",
                columns: table => new
                {
                    IdAlmacenamiento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tamaño = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Almacenamientos", x => x.IdAlmacenamiento);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Categorias = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "MemoriasRam",
                columns: table => new
                {
                    IdMemoriaRam = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RAM = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemoriasRam", x => x.IdMemoriaRam);
                });

            migrationBuilder.CreateTable(
                name: "Procesadores",
                columns: table => new
                {
                    IdProcesador = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cores = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    UrlLogo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procesadores", x => x.IdProcesador);
                });

            migrationBuilder.CreateTable(
                name: "SistemasOperativos",
                columns: table => new
                {
                    IdSistemaOperativo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    UrlLogo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SistemasOperativos", x => x.IdSistemaOperativo);
                });

            migrationBuilder.CreateTable(
                name: "TiposPantallas",
                columns: table => new
                {
                    IdTipoPantalla = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPantallas", x => x.IdTipoPantalla);
                });

            migrationBuilder.CreateTable(
                name: "Pantallas",
                columns: table => new
                {
                    IdPantalla = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Densidad = table.Column<string>(nullable: true),
                    Diagonal = table.Column<string>(nullable: true),
                    IdTipoPantalla = table.Column<int>(nullable: false),
                    Resolucion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pantallas", x => x.IdPantalla);
                    table.ForeignKey(
                        name: "FK_Pantallas_TiposPantallas_IdTipoPantalla",
                        column: x => x.IdTipoPantalla,
                        principalTable: "TiposPantallas",
                        principalColumn: "IdTipoPantalla",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Especificaciones",
                columns: table => new
                {
                    IdEspecificaciones = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Estado = table.Column<string>(nullable: true),
                    Expandible = table.Column<bool>(nullable: false),
                    IdAlmacenamiento = table.Column<int>(nullable: false),
                    IdMarca = table.Column<int>(nullable: false),
                    IdMemoriaRam = table.Column<int>(nullable: false),
                    IdPantalla = table.Column<int>(nullable: false),
                    IdProcesador = table.Column<int>(nullable: false),
                    IdSistemaOperativo = table.Column<int>(nullable: false),
                    Referencia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especificaciones", x => x.IdEspecificaciones);
                    table.ForeignKey(
                        name: "FK_Especificaciones_Almacenamientos_IdAlmacenamiento",
                        column: x => x.IdAlmacenamiento,
                        principalTable: "Almacenamientos",
                        principalColumn: "IdAlmacenamiento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Especificaciones_Marcas_IdMarca",
                        column: x => x.IdMarca,
                        principalTable: "Marcas",
                        principalColumn: "IdMarca",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Especificaciones_MemoriasRam_IdMemoriaRam",
                        column: x => x.IdMemoriaRam,
                        principalTable: "MemoriasRam",
                        principalColumn: "IdMemoriaRam",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Especificaciones_Pantallas_IdPantalla",
                        column: x => x.IdPantalla,
                        principalTable: "Pantallas",
                        principalColumn: "IdPantalla",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Especificaciones_Procesadores_IdProcesador",
                        column: x => x.IdProcesador,
                        principalTable: "Procesadores",
                        principalColumn: "IdProcesador",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Especificaciones_SistemasOperativos_IdSistemaOperativo",
                        column: x => x.IdSistemaOperativo,
                        principalTable: "SistemasOperativos",
                        principalColumn: "IdSistemaOperativo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    IdProducto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdCategoria = table.Column<int>(nullable: false),
                    IdEspecificaciones = table.Column<int>(nullable: false),
                    SeFinancia = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Especificaciones_IdEspecificaciones",
                        column: x => x.IdEspecificaciones,
                        principalTable: "Especificaciones",
                        principalColumn: "IdEspecificaciones",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Especificaciones_IdAlmacenamiento",
                table: "Especificaciones",
                column: "IdAlmacenamiento");

            migrationBuilder.CreateIndex(
                name: "IX_Especificaciones_IdMarca",
                table: "Especificaciones",
                column: "IdMarca");

            migrationBuilder.CreateIndex(
                name: "IX_Especificaciones_IdMemoriaRam",
                table: "Especificaciones",
                column: "IdMemoriaRam");

            migrationBuilder.CreateIndex(
                name: "IX_Especificaciones_IdPantalla",
                table: "Especificaciones",
                column: "IdPantalla");

            migrationBuilder.CreateIndex(
                name: "IX_Especificaciones_IdProcesador",
                table: "Especificaciones",
                column: "IdProcesador");

            migrationBuilder.CreateIndex(
                name: "IX_Especificaciones_IdSistemaOperativo",
                table: "Especificaciones",
                column: "IdSistemaOperativo");

            migrationBuilder.CreateIndex(
                name: "IX_Pantallas_IdTipoPantalla",
                table: "Pantallas",
                column: "IdTipoPantalla");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdCategoria",
                table: "Productos",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdEspecificaciones",
                table: "Productos",
                column: "IdEspecificaciones");
        }
    }
}
