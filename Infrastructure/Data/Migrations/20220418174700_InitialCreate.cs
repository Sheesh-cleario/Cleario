using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CleanerInfo",
                columns: table => new
                {
                    CleanerInfoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CleanerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CleanerInfo", x => x.CleanerInfoId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "OrderDescription",
                columns: table => new
                {
                    OrderDescriptionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    IsApprovedOrder = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDescription", x => x.OrderDescriptionId);
                });

            migrationBuilder.CreateTable(
                name: "OrderObjectDetails",
                columns: table => new
                {
                    OrderObjectDetailsId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ObjectAddres = table.Column<string>(type: "TEXT", nullable: false),
                    CleaningType = table.Column<int>(type: "INTEGER", nullable: false),
                    CleaningArea = table.Column<int>(type: "INTEGER", nullable: false),
                    CleaningDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderObjectDetails", x => x.OrderObjectDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "UserMessage",
                columns: table => new
                {
                    UserMessageId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Comment = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMessage", x => x.UserMessageId);
                });

            migrationBuilder.CreateTable(
                name: "CleaningCommand",
                columns: table => new
                {
                    CleaningCommandId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    Instruments = table.Column<string>(type: "TEXT", nullable: false),
                    Services = table.Column<string>(type: "TEXT", nullable: false),
                    OrderDescriptionId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CleaningCommand", x => x.CleaningCommandId);
                    table.ForeignKey(
                        name: "FK_CleaningCommand_OrderDescription_OrderDescriptionId",
                        column: x => x.OrderDescriptionId,
                        principalTable: "OrderDescription",
                        principalColumn: "OrderDescriptionId");
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    MessageID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserMessageId = table.Column<int>(type: "INTEGER", nullable: false),
                    MessageType = table.Column<int>(type: "INTEGER", nullable: false),
                    Sender = table.Column<int>(type: "INTEGER", nullable: false),
                    SendTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OrderDescriptionId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.MessageID);
                    table.ForeignKey(
                        name: "FK_Message_OrderDescription_OrderDescriptionId",
                        column: x => x.OrderDescriptionId,
                        principalTable: "OrderDescription",
                        principalColumn: "OrderDescriptionId");
                    table.ForeignKey(
                        name: "FK_Message_UserMessage_UserMessageId",
                        column: x => x.UserMessageId,
                        principalTable: "UserMessage",
                        principalColumn: "UserMessageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerName = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerNumber = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerEmail = table.Column<string>(type: "TEXT", nullable: false),
                    OrderObjectDetailsId = table.Column<int>(type: "INTEGER", nullable: false),
                    RelatedDataUserMessageId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderDescriptionId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_Orders_OrderDescription_OrderDescriptionId",
                        column: x => x.OrderDescriptionId,
                        principalTable: "OrderDescription",
                        principalColumn: "OrderDescriptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_OrderObjectDetails_OrderObjectDetailsId",
                        column: x => x.OrderObjectDetailsId,
                        principalTable: "OrderObjectDetails",
                        principalColumn: "OrderObjectDetailsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_UserMessage_RelatedDataUserMessageId",
                        column: x => x.RelatedDataUserMessageId,
                        principalTable: "UserMessage",
                        principalColumn: "UserMessageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UploadedFile",
                columns: table => new
                {
                    UploadedFileId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    UserMessageId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadedFile", x => x.UploadedFileId);
                    table.ForeignKey(
                        name: "FK_UploadedFile_UserMessage_UserMessageId",
                        column: x => x.UserMessageId,
                        principalTable: "UserMessage",
                        principalColumn: "UserMessageId");
                });

            migrationBuilder.CreateTable(
                name: "CleanerTeamMember",
                columns: table => new
                {
                    CleanerTeamMemberId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CleanerInfoId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsMain = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    CleaningCommandId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CleanerTeamMember", x => x.CleanerTeamMemberId);
                    table.ForeignKey(
                        name: "FK_CleanerTeamMember_CleanerInfo_CleanerInfoId",
                        column: x => x.CleanerInfoId,
                        principalTable: "CleanerInfo",
                        principalColumn: "CleanerInfoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CleanerTeamMember_CleaningCommand_CleaningCommandId",
                        column: x => x.CleaningCommandId,
                        principalTable: "CleaningCommand",
                        principalColumn: "CleaningCommandId");
                });

            migrationBuilder.CreateTable(
                name: "CleaningTask",
                columns: table => new
                {
                    CleaningTaskId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsDone = table.Column<bool>(type: "INTEGER", nullable: false),
                    TaskDescription = table.Column<string>(type: "TEXT", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CleaningTask", x => x.CleaningTaskId);
                    table.ForeignKey(
                        name: "FK_CleaningTask_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CleanerTeamMember_CleanerInfoId",
                table: "CleanerTeamMember",
                column: "CleanerInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_CleanerTeamMember_CleaningCommandId",
                table: "CleanerTeamMember",
                column: "CleaningCommandId");

            migrationBuilder.CreateIndex(
                name: "IX_CleaningCommand_OrderDescriptionId",
                table: "CleaningCommand",
                column: "OrderDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_CleaningTask_OrderId",
                table: "CleaningTask",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_OrderDescriptionId",
                table: "Message",
                column: "OrderDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_UserMessageId",
                table: "Message",
                column: "UserMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderDescriptionId",
                table: "Orders",
                column: "OrderDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderObjectDetailsId",
                table: "Orders",
                column: "OrderObjectDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RelatedDataUserMessageId",
                table: "Orders",
                column: "RelatedDataUserMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadedFile_UserMessageId",
                table: "UploadedFile",
                column: "UserMessageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CleanerTeamMember");

            migrationBuilder.DropTable(
                name: "CleaningTask");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "UploadedFile");

            migrationBuilder.DropTable(
                name: "CleanerInfo");

            migrationBuilder.DropTable(
                name: "CleaningCommand");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "OrderDescription");

            migrationBuilder.DropTable(
                name: "OrderObjectDetails");

            migrationBuilder.DropTable(
                name: "UserMessage");
        }
    }
}
