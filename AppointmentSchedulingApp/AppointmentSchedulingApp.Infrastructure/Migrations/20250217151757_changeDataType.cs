﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppointmentSchedulingApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__19093A0BFFF2A0D1", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    DeviceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Functionality = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Devices__49E1231180B6D9C3", x => x.DeviceId);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    RoomType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Rooms__328639393390FD2C", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "Slots",
                columns: table => new
                {
                    SlotId = table.Column<int>(type: "int", nullable: false),
                    SlotStartTime = table.Column<TimeOnly>(type: "time", nullable: true, defaultValueSql: "(NULL)"),
                    SlotEndTime = table.Column<TimeOnly>(type: "time", nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Slots__0A124AAF03E41AA4", x => x.SlotId);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    SpecialtyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialtyName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    SpecialtyDescription = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true, defaultValue: "https://th.bing.com/th/id/OIP.5kVbDAdvd-TbbhL31d-2sgHaE4?w=264&h=180&c=7&r=0&o=5&dpr=1.3&pid=1.7")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Specialt__D768F6A828B9E8B3", x => x.SpecialtyId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CitizenId = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    UserName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false),
                    Gender = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    Dob = table.Column<DateOnly>(type: "date", nullable: false),
                    Address = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    AvatarUrl = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    IsVerify = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__1788CC4CCC2C18AD", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "DeviceSpecialties",
                columns: table => new
                {
                    SpecialtyId = table.Column<int>(type: "int", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DeviceSp__D3F6E499279A3B83", x => new { x.SpecialtyId, x.DeviceId });
                    table.ForeignKey(
                        name: "FK__DeviceSpe__Devic__45F365D3",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "DeviceId");
                    table.ForeignKey(
                        name: "FK__DeviceSpe__Speci__44FF419A",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "SpecialtyId");
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Overview = table.Column<string>(type: "text", nullable: true),
                    Process = table.Column<string>(type: "text", nullable: true),
                    TreatmentTechniques = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Image = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false, defaultValue: "https://th.bing.com/th/id/OIP.ITpfvpcflBQwxt--PL_WegHaEc?w=252&h=180&c=7&r=0&o=5&dpr=1.3&pid=1.7"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SpecialtyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Services__C51BB00AA5CD56C8", x => x.ServiceId);
                    table.ForeignKey(
                        name: "CategoryId_FK",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: "SpecialtyId_FK",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "SpecialtyId");
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    CurrentWork = table.Column<string>(type: "text", nullable: true),
                    DoctorDescription = table.Column<string>(type: "text", nullable: false),
                    Organization = table.Column<string>(type: "text", nullable: true),
                    Prize = table.Column<string>(type: "text", nullable: true),
                    ResearchProject = table.Column<string>(type: "text", nullable: true),
                    TrainingProcess = table.Column<string>(type: "text", nullable: true),
                    WorkExperience = table.Column<string>(type: "text", nullable: true),
                    AcademicTitle = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Degree = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Doctors__2DC00EBFB42CF4E4", x => x.DoctorId);
                    table.ForeignKey(
                        name: "Doctor_FK",
                        column: x => x.DoctorId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Rank = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Patients__970EC3666A4E94A9", x => x.PatientId);
                    table.ForeignKey(
                        name: "Patient_FK",
                        column: x => x.PatientId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "DeviceServices",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DeviceSe__C185A23B1C17D30A", x => new { x.ServiceId, x.DeviceId });
                    table.ForeignKey(
                        name: "FK__DeviceSer__Devic__68487DD7",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "DeviceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__DeviceSer__Servi__6754599E",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certifications",
                columns: table => new
                {
                    CertificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    CertificationUrl = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Certific__1237E58A3720D143", x => x.CertificationId);
                    table.ForeignKey(
                        name: "Certification_FK",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId");
                });

            migrationBuilder.CreateTable(
                name: "DoctorSchedules",
                columns: table => new
                {
                    DoctorScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    DayOfWeek = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    SlotId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DoctorSc__8B4DFC5C74A646E3", x => x.DoctorScheduleId);
                    table.ForeignKey(
                        name: "DoctorId_FK",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId");
                    table.ForeignKey(
                        name: "RoomId_FK",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId");
                    table.ForeignKey(
                        name: "ServiceId_FK",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId");
                    table.ForeignKey(
                        name: "SlotId_FK",
                        column: x => x.SlotId,
                        principalTable: "Slots",
                        principalColumn: "SlotId");
                });

            migrationBuilder.CreateTable(
                name: "DoctorServices",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DoctorSe__9191B5BFE26F8888", x => new { x.DoctorId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK__DoctorSer__Docto__6B24EA82",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId");
                    table.ForeignKey(
                        name: "FK__DoctorSer__Servi__6C190EBB",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId");
                });

            migrationBuilder.CreateTable(
                name: "DoctorSpecialties",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    SpecialtyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DoctorSp__B0B681D58FD60A70", x => new { x.DoctorId, x.SpecialtyId });
                    table.ForeignKey(
                        name: "FK__DoctorSpe__Docto__4BAC3F29",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId");
                    table.ForeignKey(
                        name: "FK__DoctorSpe__Speci__4CA06362",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "SpecialtyId");
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorScheduleId = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: true),
                    PriorExaminationImg = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    AppointmentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    CancellationReason = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reservat__B7EE5F24B93F8BE2", x => x.ReservationId);
                    table.ForeignKey(
                        name: "DoctorScheduleId_FK",
                        column: x => x.DoctorScheduleId,
                        principalTable: "DoctorSchedules",
                        principalColumn: "DoctorScheduleId");
                    table.ForeignKey(
                        name: "PatientId_FK",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId");
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    ServiceFeedbackContent = table.Column<string>(type: "text", nullable: false),
                    ServiceFeedbackGrade = table.Column<int>(type: "int", nullable: true),
                    DoctorFeedbackContent = table.Column<string>(type: "text", nullable: false),
                    DoctorFeedbackGrade = table.Column<int>(type: "int", nullable: true),
                    FeedbackDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Feedback__6A4BEDD6B9B76644", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "ReservationId_FK",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "ReservationId");
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    MedicalRecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    Symptoms = table.Column<string>(type: "text", nullable: true),
                    Diagnosis = table.Column<string>(type: "text", nullable: true),
                    TreatmentPlan = table.Column<string>(type: "text", nullable: true),
                    FollowUpDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MedicalR__4411BA220AFBCBE9", x => x.MedicalRecordId);
                    table.ForeignKey(
                        name: "FK_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "ReservationId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certifications_DoctorId",
                table: "Certifications",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceServices_DeviceId",
                table: "DeviceServices",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceSpecialties_DeviceId",
                table: "DeviceSpecialties",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSchedules_DoctorId",
                table: "DoctorSchedules",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSchedules_RoomId",
                table: "DoctorSchedules",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSchedules_ServiceId",
                table: "DoctorSchedules",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSchedules_SlotId",
                table: "DoctorSchedules",
                column: "SlotId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorServices_ServiceId",
                table: "DoctorServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSpecialties_SpecialtyId",
                table: "DoctorSpecialties",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ReservationId",
                table: "Feedbacks",
                column: "ReservationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_ReservationId",
                table: "MedicalRecords",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_DoctorScheduleId",
                table: "Reservations",
                column: "DoctorScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PatientId",
                table: "Reservations",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_CategoryId",
                table: "Services",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_SpecialtyId",
                table: "Services",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "CitizenId_Unique",
                table: "Users",
                column: "CitizenId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Email_Unique",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "Phone_Unique",
                table: "Users",
                column: "Phone",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certifications");

            migrationBuilder.DropTable(
                name: "DeviceServices");

            migrationBuilder.DropTable(
                name: "DeviceSpecialties");

            migrationBuilder.DropTable(
                name: "DoctorServices");

            migrationBuilder.DropTable(
                name: "DoctorSpecialties");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "DoctorSchedules");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Slots");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Specialties");
        }
    }
}
