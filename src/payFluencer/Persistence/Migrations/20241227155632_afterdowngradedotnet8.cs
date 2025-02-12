using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class afterdowngradedotnet8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disputes_Gigs_GigId",
                table: "Disputes");

            migrationBuilder.DropForeignKey(
                name: "FK_Gigs_Influencers_InfluencerId",
                table: "Gigs");

            migrationBuilder.DropForeignKey(
                name: "FK_Gigs_Posts_PostId",
                table: "Gigs");

            migrationBuilder.DropForeignKey(
                name: "FK_Gigs_Sponsors_SponsorId",
                table: "Gigs");

            migrationBuilder.DropForeignKey(
                name: "FK_InfluencerReviews_Gigs_GigId1",
                table: "InfluencerReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_PostGigs_Gigs_GigId",
                table: "PostGigs");

            migrationBuilder.DropForeignKey(
                name: "FK_PostGigs_Posts_PostId",
                table: "PostGigs");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Sponsors_SponsorId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_SponsorReviews_Gigs_GigId1",
                table: "SponsorReviews");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("035fa361-19e0-4e0d-8847-742be0b1e177"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22a083cf-9100-44e4-ae42-2ee936b8b4b7"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("3cc74077-84a0-43ff-af83-b9f2bb3bcc96"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 46, 134, 166, 27, 91, 51, 37, 154, 233, 24, 140, 56, 30, 49, 63, 104, 120, 158, 192, 1, 138, 195, 199, 138, 67, 22, 151, 10, 57, 119, 172, 187, 34, 159, 48, 174, 220, 73, 145, 215, 246, 117, 128, 131, 31, 20, 156, 72, 123, 145, 69, 3, 16, 139, 214, 158, 153, 186, 58, 94, 131, 58, 65, 160 }, new byte[] { 76, 210, 26, 198, 175, 239, 88, 243, 173, 136, 26, 109, 230, 165, 191, 231, 183, 184, 99, 98, 178, 227, 115, 220, 218, 27, 43, 196, 237, 179, 124, 181, 109, 110, 125, 86, 145, 231, 191, 133, 224, 12, 49, 149, 77, 134, 52, 82, 199, 158, 199, 105, 251, 220, 147, 82, 94, 176, 149, 225, 18, 171, 97, 66, 91, 63, 105, 172, 71, 105, 24, 187, 92, 160, 100, 45, 189, 240, 13, 82, 101, 163, 103, 142, 141, 224, 147, 144, 173, 52, 87, 26, 11, 151, 98, 124, 36, 56, 253, 101, 164, 238, 166, 176, 93, 236, 152, 123, 198, 1, 43, 67, 118, 213, 126, 101, 59, 125, 179, 17, 102, 180, 78, 72, 76, 252, 55, 0 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("9a24f6dd-2287-451c-95cb-0c94f7e82cce"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("3cc74077-84a0-43ff-af83-b9f2bb3bcc96") });

            migrationBuilder.AddForeignKey(
                name: "FK_Disputes_Gigs_GigId",
                table: "Disputes",
                column: "GigId",
                principalTable: "Gigs",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Gigs_Influencers_InfluencerId",
                table: "Gigs",
                column: "InfluencerId",
                principalTable: "Influencers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Gigs_Posts_PostId",
                table: "Gigs",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Gigs_Sponsors_SponsorId",
                table: "Gigs",
                column: "SponsorId",
                principalTable: "Sponsors",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_InfluencerReviews_Gigs_GigId1",
                table: "InfluencerReviews",
                column: "GigId1",
                principalTable: "Gigs",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PostGigs_Gigs_GigId",
                table: "PostGigs",
                column: "GigId",
                principalTable: "Gigs",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PostGigs_Posts_PostId",
                table: "PostGigs",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Sponsors_SponsorId",
                table: "Posts",
                column: "SponsorId",
                principalTable: "Sponsors",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SponsorReviews_Gigs_GigId1",
                table: "SponsorReviews",
                column: "GigId1",
                principalTable: "Gigs",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disputes_Gigs_GigId",
                table: "Disputes");

            migrationBuilder.DropForeignKey(
                name: "FK_Gigs_Influencers_InfluencerId",
                table: "Gigs");

            migrationBuilder.DropForeignKey(
                name: "FK_Gigs_Posts_PostId",
                table: "Gigs");

            migrationBuilder.DropForeignKey(
                name: "FK_Gigs_Sponsors_SponsorId",
                table: "Gigs");

            migrationBuilder.DropForeignKey(
                name: "FK_InfluencerReviews_Gigs_GigId1",
                table: "InfluencerReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_PostGigs_Gigs_GigId",
                table: "PostGigs");

            migrationBuilder.DropForeignKey(
                name: "FK_PostGigs_Posts_PostId",
                table: "PostGigs");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Sponsors_SponsorId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_SponsorReviews_Gigs_GigId1",
                table: "SponsorReviews");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("9a24f6dd-2287-451c-95cb-0c94f7e82cce"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3cc74077-84a0-43ff-af83-b9f2bb3bcc96"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("22a083cf-9100-44e4-ae42-2ee936b8b4b7"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 228, 98, 159, 248, 197, 87, 181, 198, 69, 125, 149, 160, 1, 248, 227, 64, 20, 160, 23, 228, 125, 253, 189, 8, 129, 209, 133, 76, 226, 67, 242, 84, 81, 187, 188, 15, 184, 67, 175, 89, 170, 138, 183, 38, 106, 202, 54, 2, 171, 221, 218, 11, 103, 243, 19, 156, 223, 59, 8, 184, 132, 127, 151, 123 }, new byte[] { 61, 186, 70, 85, 11, 212, 98, 164, 50, 114, 243, 3, 78, 226, 155, 109, 104, 58, 104, 215, 121, 54, 27, 220, 74, 78, 76, 48, 235, 174, 226, 94, 108, 43, 192, 4, 131, 246, 146, 67, 154, 108, 63, 4, 99, 222, 87, 122, 211, 170, 42, 226, 210, 52, 206, 162, 72, 230, 120, 219, 2, 218, 243, 218, 157, 73, 95, 149, 44, 229, 157, 92, 178, 127, 44, 207, 168, 154, 54, 109, 81, 150, 80, 108, 37, 150, 90, 65, 47, 2, 173, 68, 100, 252, 3, 4, 130, 225, 204, 113, 73, 43, 25, 239, 49, 200, 46, 57, 171, 244, 194, 5, 43, 23, 152, 228, 249, 123, 167, 183, 89, 109, 219, 210, 70, 85, 247, 76 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("035fa361-19e0-4e0d-8847-742be0b1e177"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("22a083cf-9100-44e4-ae42-2ee936b8b4b7") });

            migrationBuilder.AddForeignKey(
                name: "FK_Disputes_Gigs_GigId",
                table: "Disputes",
                column: "GigId",
                principalTable: "Gigs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gigs_Influencers_InfluencerId",
                table: "Gigs",
                column: "InfluencerId",
                principalTable: "Influencers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gigs_Posts_PostId",
                table: "Gigs",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gigs_Sponsors_SponsorId",
                table: "Gigs",
                column: "SponsorId",
                principalTable: "Sponsors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InfluencerReviews_Gigs_GigId1",
                table: "InfluencerReviews",
                column: "GigId1",
                principalTable: "Gigs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostGigs_Gigs_GigId",
                table: "PostGigs",
                column: "GigId",
                principalTable: "Gigs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostGigs_Posts_PostId",
                table: "PostGigs",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Sponsors_SponsorId",
                table: "Posts",
                column: "SponsorId",
                principalTable: "Sponsors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SponsorReviews_Gigs_GigId1",
                table: "SponsorReviews",
                column: "GigId1",
                principalTable: "Gigs",
                principalColumn: "Id");
        }
    }
}
