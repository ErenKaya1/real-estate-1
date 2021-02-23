using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.Dal.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ambit_property",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PropertyNameTR = table.Column<string>(maxLength: 50, nullable: false),
                    PropertyNameEN = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ambit_property", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(type: "varchar(50)", maxLength: 256, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "varchar(12)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 256, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "varchar(100)", maxLength: 256, nullable: false),
                    PasswordHash = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "building_type",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BuildingTypeNameTR = table.Column<string>(maxLength: 30, nullable: false),
                    BuildingTypeNameEN = table.Column<string>(maxLength: 30, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_building_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "estate_type",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TypeNameTR = table.Column<string>(maxLength: 30, nullable: false),
                    TypeNameEN = table.Column<string>(maxLength: 30, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estate_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "external_property",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PropertyNameTR = table.Column<string>(maxLength: 50, nullable: false),
                    PropertyNameEN = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_external_property", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "interior_property",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PropertyNameTR = table.Column<string>(maxLength: 50, nullable: false),
                    PropertyNameEN = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_interior_property", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "province",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameTR = table.Column<string>(maxLength: 30, nullable: false),
                    NameEN = table.Column<string>(maxLength: 30, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_province", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "title_deed_status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusNameTR = table.Column<string>(maxLength: 30, nullable: false),
                    StatusNameEN = table.Column<string>(maxLength: 30, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_title_deed_status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "transportation_property",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PropertyNameTR = table.Column<string>(maxLength: 50, nullable: false),
                    PropertyNameEN = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transportation_property", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "warming_way",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WarmingWayNameTR = table.Column<string>(maxLength: 30, nullable: false),
                    WarmingWayNameEN = table.Column<string>(maxLength: 30, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warming_way", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "district",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DistrictNameTR = table.Column<string>(maxLength: 30, nullable: false),
                    DistrictNameEN = table.Column<string>(maxLength: 30, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ProvinceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_district", x => x.Id);
                    table.ForeignKey(
                        name: "FK_district_province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "estate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    UrlPath = table.Column<string>(nullable: true),
                    PriceTRY = table.Column<double>(nullable: false),
                    M2 = table.Column<string>(nullable: true),
                    RoomCount = table.Column<string>(nullable: true),
                    FloorNumber = table.Column<string>(nullable: true),
                    TotalFloor = table.Column<string>(nullable: true),
                    BuildingStatus = table.Column<byte>(nullable: false),
                    SaleType = table.Column<byte>(nullable: false),
                    BuildingAge = table.Column<string>(nullable: true),
                    WarmingWayId = table.Column<int>(nullable: false),
                    AvailableForLoan = table.Column<byte>(nullable: false),
                    FurnitureStatus = table.Column<byte>(nullable: false),
                    BathroomCount = table.Column<string>(nullable: true),
                    BuildingState = table.Column<byte>(nullable: false),
                    BuildingTypeId = table.Column<int>(nullable: false),
                    TitleDeedStatusId = table.Column<int>(nullable: false),
                    UsingStatus = table.Column<byte>(nullable: false),
                    AvailableForTrade = table.Column<byte>(nullable: false),
                    Facade = table.Column<byte>(nullable: false),
                    DescriptionTR = table.Column<string>(nullable: true),
                    DescriptionEN = table.Column<string>(nullable: true),
                    EstateTypeId = table.Column<int>(nullable: false),
                    ProvinceId = table.Column<int>(nullable: false),
                    DistrictId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    GoogleMapIframe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_estate_building_type_BuildingTypeId",
                        column: x => x.BuildingTypeId,
                        principalTable: "building_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_estate_district_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "district",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_estate_estate_type_EstateTypeId",
                        column: x => x.EstateTypeId,
                        principalTable: "estate_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_estate_province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_estate_title_deed_status_TitleDeedStatusId",
                        column: x => x.TitleDeedStatusId,
                        principalTable: "title_deed_status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_estate_warming_way_WarmingWayId",
                        column: x => x.WarmingWayId,
                        principalTable: "warming_way",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "estate_ambit_property",
                columns: table => new
                {
                    EstateId = table.Column<int>(nullable: false),
                    AmbitPropertyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estate_ambit_property", x => new { x.EstateId, x.AmbitPropertyId });
                    table.ForeignKey(
                        name: "FK_estate_ambit_property_ambit_property_AmbitPropertyId",
                        column: x => x.AmbitPropertyId,
                        principalTable: "ambit_property",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_estate_ambit_property_estate_EstateId",
                        column: x => x.EstateId,
                        principalTable: "estate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "estate_external_property",
                columns: table => new
                {
                    EstateId = table.Column<int>(nullable: false),
                    ExternalPropertyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estate_external_property", x => new { x.EstateId, x.ExternalPropertyId });
                    table.ForeignKey(
                        name: "FK_estate_external_property_estate_EstateId",
                        column: x => x.EstateId,
                        principalTable: "estate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_estate_external_property_external_property_ExternalPropertyId",
                        column: x => x.ExternalPropertyId,
                        principalTable: "external_property",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "estate_interior_property",
                columns: table => new
                {
                    EstateId = table.Column<int>(nullable: false),
                    InteriorPropertyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estate_interior_property", x => new { x.EstateId, x.InteriorPropertyId });
                    table.ForeignKey(
                        name: "FK_estate_interior_property_estate_EstateId",
                        column: x => x.EstateId,
                        principalTable: "estate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_estate_interior_property_interior_property_InteriorPropertyId",
                        column: x => x.InteriorPropertyId,
                        principalTable: "interior_property",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "estate_transportation_property",
                columns: table => new
                {
                    EstateId = table.Column<int>(nullable: false),
                    TransportationPropertyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estate_transportation_property", x => new { x.EstateId, x.TransportationPropertyId });
                    table.ForeignKey(
                        name: "FK_estate_transportation_property_estate_EstateId",
                        column: x => x.EstateId,
                        principalTable: "estate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_estate_transportation_property_transportation_property_Trans~",
                        column: x => x.TransportationPropertyId,
                        principalTable: "transportation_property",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "panoramic_image",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ImageName = table.Column<string>(maxLength: 100, nullable: false),
                    CustomId = table.Column<string>(maxLength: 30, nullable: false),
                    Sort = table.Column<string>(maxLength: 3, nullable: false),
                    EstateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_panoramic_image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_panoramic_image_estate_EstateId",
                        column: x => x.EstateId,
                        principalTable: "estate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "static_image",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ImageName = table.Column<string>(maxLength: 100, nullable: false),
                    CustomId = table.Column<string>(maxLength: 30, nullable: false),
                    Sort = table.Column<string>(maxLength: 3, nullable: false),
                    EstateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_static_image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_static_image_estate_EstateId",
                        column: x => x.EstateId,
                        principalTable: "estate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_district_ProvinceId",
                table: "district",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_estate_BuildingTypeId",
                table: "estate",
                column: "BuildingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_estate_CustomId",
                table: "estate",
                column: "CustomId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_estate_DistrictId",
                table: "estate",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_estate_EstateTypeId",
                table: "estate",
                column: "EstateTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_estate_ProvinceId",
                table: "estate",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_estate_Title",
                table: "estate",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_estate_TitleDeedStatusId",
                table: "estate",
                column: "TitleDeedStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_estate_UrlPath",
                table: "estate",
                column: "UrlPath",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_estate_WarmingWayId",
                table: "estate",
                column: "WarmingWayId");

            migrationBuilder.CreateIndex(
                name: "IX_estate_ambit_property_AmbitPropertyId",
                table: "estate_ambit_property",
                column: "AmbitPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_estate_external_property_ExternalPropertyId",
                table: "estate_external_property",
                column: "ExternalPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_estate_interior_property_InteriorPropertyId",
                table: "estate_interior_property",
                column: "InteriorPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_estate_transportation_property_TransportationPropertyId",
                table: "estate_transportation_property",
                column: "TransportationPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_panoramic_image_EstateId",
                table: "panoramic_image",
                column: "EstateId");

            migrationBuilder.CreateIndex(
                name: "IX_static_image_EstateId",
                table: "static_image",
                column: "EstateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "estate_ambit_property");

            migrationBuilder.DropTable(
                name: "estate_external_property");

            migrationBuilder.DropTable(
                name: "estate_interior_property");

            migrationBuilder.DropTable(
                name: "estate_transportation_property");

            migrationBuilder.DropTable(
                name: "panoramic_image");

            migrationBuilder.DropTable(
                name: "static_image");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ambit_property");

            migrationBuilder.DropTable(
                name: "external_property");

            migrationBuilder.DropTable(
                name: "interior_property");

            migrationBuilder.DropTable(
                name: "transportation_property");

            migrationBuilder.DropTable(
                name: "estate");

            migrationBuilder.DropTable(
                name: "building_type");

            migrationBuilder.DropTable(
                name: "district");

            migrationBuilder.DropTable(
                name: "estate_type");

            migrationBuilder.DropTable(
                name: "title_deed_status");

            migrationBuilder.DropTable(
                name: "warming_way");

            migrationBuilder.DropTable(
                name: "province");
        }
    }
}
