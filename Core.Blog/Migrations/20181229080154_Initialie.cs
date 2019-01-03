using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Blog.Migrations
{
    public partial class Initialie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdvertisementInfo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Createdate = table.Column<DateTime>(nullable: false),
                    ImgUrl = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TechnologyClassifyInfo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnologyClassifyInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PassWord = table.Column<string>(nullable: true),
                    PassKey = table.Column<string>(nullable: true),
                    BlogUrl = table.Column<string>(nullable: true),
                    LoveSentence = table.Column<string>(nullable: true),
                    HeadUrl = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    LastErrTime = table.Column<DateTime>(nullable: false),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BlogPostsInfo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    TechnologyClassifyID = table.Column<int>(nullable: false),
                    TechnologyClassifyInfoID = table.Column<int>(nullable: true),
                    KeyWords = table.Column<string>(nullable: true),
                    Describe = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    Heat = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserInfoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPostsInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BlogPostsInfo_TechnologyClassifyInfo_TechnologyClassifyInfoID",
                        column: x => x.TechnologyClassifyInfoID,
                        principalTable: "TechnologyClassifyInfo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BlogPostsInfo_UserInfo_UserInfoID",
                        column: x => x.UserInfoID,
                        principalTable: "UserInfo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserCollectInfo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    UserInfoID = table.Column<int>(nullable: true),
                    CollID = table.Column<int>(nullable: false),
                    CollType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCollectInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserCollectInfo_UserInfo_UserInfoID",
                        column: x => x.UserInfoID,
                        principalTable: "UserInfo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArticleCommentsInfo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PostsID = table.Column<string>(nullable: true),
                    BlogPostsInfoID = table.Column<int>(nullable: true),
                    PID = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    UserInfoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCommentsInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ArticleCommentsInfo_BlogPostsInfo_BlogPostsInfoID",
                        column: x => x.BlogPostsInfoID,
                        principalTable: "BlogPostsInfo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArticleCommentsInfo_UserInfo_UserInfoID",
                        column: x => x.UserInfoID,
                        principalTable: "UserInfo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCommentsInfo_BlogPostsInfoID",
                table: "ArticleCommentsInfo",
                column: "BlogPostsInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCommentsInfo_UserInfoID",
                table: "ArticleCommentsInfo",
                column: "UserInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostsInfo_TechnologyClassifyInfoID",
                table: "BlogPostsInfo",
                column: "TechnologyClassifyInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostsInfo_UserInfoID",
                table: "BlogPostsInfo",
                column: "UserInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_UserCollectInfo_UserInfoID",
                table: "UserCollectInfo",
                column: "UserInfoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvertisementInfo");

            migrationBuilder.DropTable(
                name: "ArticleCommentsInfo");

            migrationBuilder.DropTable(
                name: "UserCollectInfo");

            migrationBuilder.DropTable(
                name: "BlogPostsInfo");

            migrationBuilder.DropTable(
                name: "TechnologyClassifyInfo");

            migrationBuilder.DropTable(
                name: "UserInfo");
        }
    }
}
