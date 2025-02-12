using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class newtry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("56377a6c-e463-45eb-bda3-4db3b93215bf"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7674e0ac-aade-478f-b7cd-d9e647197edf"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("22a083cf-9100-44e4-ae42-2ee936b8b4b7"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 228, 98, 159, 248, 197, 87, 181, 198, 69, 125, 149, 160, 1, 248, 227, 64, 20, 160, 23, 228, 125, 253, 189, 8, 129, 209, 133, 76, 226, 67, 242, 84, 81, 187, 188, 15, 184, 67, 175, 89, 170, 138, 183, 38, 106, 202, 54, 2, 171, 221, 218, 11, 103, 243, 19, 156, 223, 59, 8, 184, 132, 127, 151, 123 }, new byte[] { 61, 186, 70, 85, 11, 212, 98, 164, 50, 114, 243, 3, 78, 226, 155, 109, 104, 58, 104, 215, 121, 54, 27, 220, 74, 78, 76, 48, 235, 174, 226, 94, 108, 43, 192, 4, 131, 246, 146, 67, 154, 108, 63, 4, 99, 222, 87, 122, 211, 170, 42, 226, 210, 52, 206, 162, 72, 230, 120, 219, 2, 218, 243, 218, 157, 73, 95, 149, 44, 229, 157, 92, 178, 127, 44, 207, 168, 154, 54, 109, 81, 150, 80, 108, 37, 150, 90, 65, 47, 2, 173, 68, 100, 252, 3, 4, 130, 225, 204, 113, 73, 43, 25, 239, 49, 200, 46, 57, 171, 244, 194, 5, 43, 23, 152, 228, 249, 123, 167, 183, 89, 109, 219, 210, 70, 85, 247, 76 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("035fa361-19e0-4e0d-8847-742be0b1e177"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("22a083cf-9100-44e4-ae42-2ee936b8b4b7") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { new Guid("7674e0ac-aade-478f-b7cd-d9e647197edf"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 194, 248, 231, 147, 65, 252, 183, 63, 12, 63, 223, 203, 195, 8, 194, 110, 160, 167, 110, 166, 176, 153, 105, 98, 60, 229, 62, 9, 252, 19, 56, 219, 242, 234, 111, 243, 191, 142, 43, 247, 102, 8, 228, 106, 189, 209, 163, 78, 128, 45, 246, 118, 105, 101, 139, 41, 6, 0, 170, 16, 224, 109, 245, 26 }, new byte[] { 107, 207, 211, 128, 76, 6, 242, 112, 62, 173, 164, 210, 40, 44, 178, 111, 190, 74, 9, 161, 30, 16, 156, 255, 38, 219, 230, 192, 111, 28, 36, 75, 64, 177, 142, 192, 87, 188, 207, 249, 251, 182, 125, 217, 83, 153, 84, 129, 52, 43, 182, 213, 216, 33, 119, 25, 102, 17, 33, 191, 163, 47, 2, 145, 118, 119, 208, 140, 45, 242, 246, 33, 68, 8, 22, 56, 117, 42, 139, 19, 152, 125, 21, 123, 245, 26, 4, 95, 34, 153, 142, 186, 28, 174, 125, 131, 135, 177, 212, 72, 193, 184, 112, 110, 3, 167, 219, 135, 205, 76, 62, 50, 52, 77, 156, 115, 231, 50, 196, 72, 166, 152, 108, 191, 24, 82, 105, 85 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("56377a6c-e463-45eb-bda3-4db3b93215bf"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("7674e0ac-aade-478f-b7cd-d9e647197edf") });
        }
    }
}
