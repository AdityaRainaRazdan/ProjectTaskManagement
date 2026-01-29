using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectTaskManage.Module.Migrations
{
    /// <inheritdoc />
    public partial class start : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditEFCoreWeakReferences",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GCRecord = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    TypeName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DefaultString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditEFCoreWeakReferences", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DashboardData",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SynchronizeTitle = table.Column<bool>(type: "bit", nullable: false),
                    GCRecord = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardData", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AllDay = table.Column<bool>(type: "bit", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Label = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    RecurrenceInfoXml = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    RecurrencePatternID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReminderInfoXml = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RemindIn = table.Column<TimeSpan>(type: "time", nullable: true),
                    AlarmTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPostponed = table.Column<bool>(type: "bit", nullable: false),
                    GCRecord = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Events_Events_RecurrencePatternID",
                        column: x => x.RecurrencePatternID,
                        principalTable: "Events",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "FileData",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileData", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HCategories",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HCategories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HCategories_HCategories_ParentID",
                        column: x => x.ParentID,
                        principalTable: "HCategories",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    GCRecord = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ModelDifferences",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContextId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false),
                    GCRecord = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelDifferences", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PermissionPolicyRoleBase",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdministrative = table.Column<bool>(type: "bit", nullable: false),
                    CanEditModel = table.Column<bool>(type: "bit", nullable: false),
                    PermissionPolicy = table.Column<int>(type: "int", nullable: false),
                    IsAllowPermissionPriority = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: false),
                    GCRecord = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyRoleBase", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PermissionPolicyUser",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ChangePasswordOnFirstLogon = table.Column<bool>(type: "bit", nullable: false),
                    StoredPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: true),
                    LockoutEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyUser", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ReportDataV2",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsInplaceReport = table.Column<bool>(type: "bit", nullable: false),
                    PredefinedReportTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParametersObjectTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportDataV2", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    Key = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color_Int = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "AuditData",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OperationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditedObjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OldObjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NewObjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserObjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditData", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AuditData_AuditEFCoreWeakReferences_AuditedObjectID",
                        column: x => x.AuditedObjectID,
                        principalTable: "AuditEFCoreWeakReferences",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_AuditData_AuditEFCoreWeakReferences_NewObjectID",
                        column: x => x.NewObjectID,
                        principalTable: "AuditEFCoreWeakReferences",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_AuditData_AuditEFCoreWeakReferences_OldObjectID",
                        column: x => x.OldObjectID,
                        principalTable: "AuditEFCoreWeakReferences",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_AuditData_AuditEFCoreWeakReferences_UserObjectID",
                        column: x => x.UserObjectID,
                        principalTable: "AuditEFCoreWeakReferences",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceLineItems",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvoiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceLineItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InvoiceLineItems_Invoices_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ModelDifferenceAspects",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Xml = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelDifferenceAspects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ModelDifferenceAspects_ModelDifferences_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "ModelDifferences",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionPolicyActionPermissionObject",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ActionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyActionPermissionObject", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PermissionPolicyActionPermissionObject_PermissionPolicyRoleBase_RoleID",
                        column: x => x.RoleID,
                        principalTable: "PermissionPolicyRoleBase",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionPolicyNavigationPermissionObject",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetTypeFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NavigateState = table.Column<int>(type: "int", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyNavigationPermissionObject", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PermissionPolicyNavigationPermissionObject_PermissionPolicyRoleBase_RoleID",
                        column: x => x.RoleID,
                        principalTable: "PermissionPolicyRoleBase",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionPolicyTypePermissionObject",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TargetTypeFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReadState = table.Column<int>(type: "int", nullable: true),
                    WriteState = table.Column<int>(type: "int", nullable: true),
                    CreateState = table.Column<int>(type: "int", nullable: true),
                    DeleteState = table.Column<int>(type: "int", nullable: true),
                    NavigateState = table.Column<int>(type: "int", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyTypePermissionObject", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PermissionPolicyTypePermissionObject_PermissionPolicyRoleBase_RoleID",
                        column: x => x.RoleID,
                        principalTable: "PermissionPolicyRoleBase",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    OrganizationID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Designation = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employees_Organizations_OrganizationID",
                        column: x => x.OrganizationID,
                        principalTable: "Organizations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Employees_PermissionPolicyUser_UserID",
                        column: x => x.UserID,
                        principalTable: "PermissionPolicyUser",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PermissionPolicyRolePermissionPolicyUser",
                columns: table => new
                {
                    RolesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyRolePermissionPolicyUser", x => new { x.RolesID, x.UsersID });
                    table.ForeignKey(
                        name: "FK_PermissionPolicyRolePermissionPolicyUser_PermissionPolicyRoleBase_RolesID",
                        column: x => x.RolesID,
                        principalTable: "PermissionPolicyRoleBase",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionPolicyRolePermissionPolicyUser_PermissionPolicyUser_UsersID",
                        column: x => x.UsersID,
                        principalTable: "PermissionPolicyUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionPolicyUserLoginInfo",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProviderName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProviderUserKey = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserForeignKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GCRecord = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyUserLoginInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PermissionPolicyUserLoginInfo_PermissionPolicyUser_UserForeignKey",
                        column: x => x.UserForeignKey,
                        principalTable: "PermissionPolicyUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventResource",
                columns: table => new
                {
                    EventsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResourcesKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventResource", x => new { x.EventsID, x.ResourcesKey });
                    table.ForeignKey(
                        name: "FK_EventResource_Events_EventsID",
                        column: x => x.EventsID,
                        principalTable: "Events",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventResource_Resource_ResourcesKey",
                        column: x => x.ResourcesKey,
                        principalTable: "Resource",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionPolicyMemberPermissionsObject",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Members = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Criteria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReadState = table.Column<int>(type: "int", nullable: true),
                    WriteState = table.Column<int>(type: "int", nullable: true),
                    TypePermissionObjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyMemberPermissionsObject", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PermissionPolicyMemberPermissionsObject_PermissionPolicyTypePermissionObject_TypePermissionObjectID",
                        column: x => x.TypePermissionObjectID,
                        principalTable: "PermissionPolicyTypePermissionObject",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionPolicyObjectPermissionsObject",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Criteria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReadState = table.Column<int>(type: "int", nullable: true),
                    WriteState = table.Column<int>(type: "int", nullable: true),
                    DeleteState = table.Column<int>(type: "int", nullable: true),
                    NavigateState = table.Column<int>(type: "int", nullable: true),
                    TypePermissionObjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyObjectPermissionsObject", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PermissionPolicyObjectPermissionsObject_PermissionPolicyTypePermissionObject_TypePermissionObjectID",
                        column: x => x.TypePermissionObjectID,
                        principalTable: "PermissionPolicyTypePermissionObject",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeFiles",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    FileID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeFiles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EmployeeFiles_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_EmployeeFiles_FileData_FileID",
                        column: x => x.FileID,
                        principalTable: "FileData",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceApprovalHistories",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PerformedByID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceApprovalHistories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InvoiceApprovalHistories_Employees_PerformedByID",
                        column: x => x.PerformedByID,
                        principalTable: "Employees",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_InvoiceApprovalHistories_Invoices_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrganizationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectManagerID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Projects_Employees_ProjectManagerID",
                        column: x => x.ProjectManagerID,
                        principalTable: "Employees",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Projects_Organizations_OrganizationID",
                        column: x => x.OrganizationID,
                        principalTable: "Organizations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTasks",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssignedToID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTasks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjectTasks_Employees_AssignedToID",
                        column: x => x.AssignedToID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ProjectTasks_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "StateMachineAppearances",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TargetItems = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppearanceItemType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Criteria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Context = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    FontStyle = table.Column<int>(type: "int", nullable: true),
                    FontColorInt = table.Column<int>(type: "int", nullable: false),
                    BackColorInt = table.Column<int>(type: "int", nullable: false),
                    Visibility = table.Column<int>(type: "int", nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: true),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateMachineAppearances", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StateMachines",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    TargetObjectTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatePropertyNameBase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartStateID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExpandActionsInDetailView = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateMachines", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StateMachineStates",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StateMachineID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarkerValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetObjectCriteria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateMachineStates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StateMachineStates_StateMachines_StateMachineID",
                        column: x => x.StateMachineID,
                        principalTable: "StateMachines",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StateMachineTransitions",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceStateID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TargetStateID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Index = table.Column<int>(type: "int", nullable: false),
                    SaveAndCloseView = table.Column<bool>(type: "bit", nullable: false),
                    GCRecord = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateMachineTransitions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StateMachineTransitions_StateMachineStates_SourceStateID",
                        column: x => x.SourceStateID,
                        principalTable: "StateMachineStates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StateMachineTransitions_StateMachineStates_TargetStateID",
                        column: x => x.TargetStateID,
                        principalTable: "StateMachineStates",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditData_AuditedObjectID",
                table: "AuditData",
                column: "AuditedObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_AuditData_NewObjectID",
                table: "AuditData",
                column: "NewObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_AuditData_OldObjectID",
                table: "AuditData",
                column: "OldObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_AuditData_UserObjectID",
                table: "AuditData",
                column: "UserObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_AuditEFCoreWeakReferences_Key_TypeName",
                table: "AuditEFCoreWeakReferences",
                columns: new[] { "Key", "TypeName" });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeFiles_EmployeeID",
                table: "EmployeeFiles",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeFiles_FileID",
                table: "EmployeeFiles",
                column: "FileID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_OrganizationID",
                table: "Employees",
                column: "OrganizationID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserID",
                table: "Employees",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_EventResource_ResourcesKey",
                table: "EventResource",
                column: "ResourcesKey");

            migrationBuilder.CreateIndex(
                name: "IX_Events_RecurrencePatternID",
                table: "Events",
                column: "RecurrencePatternID");

            migrationBuilder.CreateIndex(
                name: "IX_HCategories_ParentID",
                table: "HCategories",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceApprovalHistories_InvoiceID",
                table: "InvoiceApprovalHistories",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceApprovalHistories_PerformedByID",
                table: "InvoiceApprovalHistories",
                column: "PerformedByID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLineItems_InvoiceID",
                table: "InvoiceLineItems",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_ModelDifferenceAspects_OwnerID",
                table: "ModelDifferenceAspects",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionPolicyActionPermissionObject_RoleID",
                table: "PermissionPolicyActionPermissionObject",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionPolicyMemberPermissionsObject_TypePermissionObjectID",
                table: "PermissionPolicyMemberPermissionsObject",
                column: "TypePermissionObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionPolicyNavigationPermissionObject_RoleID",
                table: "PermissionPolicyNavigationPermissionObject",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionPolicyObjectPermissionsObject_TypePermissionObjectID",
                table: "PermissionPolicyObjectPermissionsObject",
                column: "TypePermissionObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionPolicyRolePermissionPolicyUser_UsersID",
                table: "PermissionPolicyRolePermissionPolicyUser",
                column: "UsersID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionPolicyTypePermissionObject_RoleID",
                table: "PermissionPolicyTypePermissionObject",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionPolicyUserLoginInfo_LoginProviderName_ProviderUserKey",
                table: "PermissionPolicyUserLoginInfo",
                columns: new[] { "LoginProviderName", "ProviderUserKey" },
                unique: true,
                filter: "[LoginProviderName] IS NOT NULL AND [ProviderUserKey] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionPolicyUserLoginInfo_UserForeignKey",
                table: "PermissionPolicyUserLoginInfo",
                column: "UserForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_OrganizationID",
                table: "Projects",
                column: "OrganizationID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectManagerID",
                table: "Projects",
                column: "ProjectManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_AssignedToID",
                table: "ProjectTasks",
                column: "AssignedToID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_ProjectID",
                table: "ProjectTasks",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_StateMachineAppearances_StateID",
                table: "StateMachineAppearances",
                column: "StateID");

            migrationBuilder.CreateIndex(
                name: "IX_StateMachines_StartStateID",
                table: "StateMachines",
                column: "StartStateID");

            migrationBuilder.CreateIndex(
                name: "IX_StateMachineStates_StateMachineID",
                table: "StateMachineStates",
                column: "StateMachineID");

            migrationBuilder.CreateIndex(
                name: "IX_StateMachineTransitions_SourceStateID",
                table: "StateMachineTransitions",
                column: "SourceStateID");

            migrationBuilder.CreateIndex(
                name: "IX_StateMachineTransitions_TargetStateID",
                table: "StateMachineTransitions",
                column: "TargetStateID");

            migrationBuilder.AddForeignKey(
                name: "FK_StateMachineAppearances_StateMachineStates_StateID",
                table: "StateMachineAppearances",
                column: "StateID",
                principalTable: "StateMachineStates",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StateMachines_StateMachineStates_StartStateID",
                table: "StateMachines",
                column: "StartStateID",
                principalTable: "StateMachineStates",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StateMachines_StateMachineStates_StartStateID",
                table: "StateMachines");

            migrationBuilder.DropTable(
                name: "AuditData");

            migrationBuilder.DropTable(
                name: "DashboardData");

            migrationBuilder.DropTable(
                name: "EmployeeFiles");

            migrationBuilder.DropTable(
                name: "EventResource");

            migrationBuilder.DropTable(
                name: "HCategories");

            migrationBuilder.DropTable(
                name: "InvoiceApprovalHistories");

            migrationBuilder.DropTable(
                name: "InvoiceLineItems");

            migrationBuilder.DropTable(
                name: "ModelDifferenceAspects");

            migrationBuilder.DropTable(
                name: "PermissionPolicyActionPermissionObject");

            migrationBuilder.DropTable(
                name: "PermissionPolicyMemberPermissionsObject");

            migrationBuilder.DropTable(
                name: "PermissionPolicyNavigationPermissionObject");

            migrationBuilder.DropTable(
                name: "PermissionPolicyObjectPermissionsObject");

            migrationBuilder.DropTable(
                name: "PermissionPolicyRolePermissionPolicyUser");

            migrationBuilder.DropTable(
                name: "PermissionPolicyUserLoginInfo");

            migrationBuilder.DropTable(
                name: "ProjectTasks");

            migrationBuilder.DropTable(
                name: "ReportDataV2");

            migrationBuilder.DropTable(
                name: "StateMachineAppearances");

            migrationBuilder.DropTable(
                name: "StateMachineTransitions");

            migrationBuilder.DropTable(
                name: "AuditEFCoreWeakReferences");

            migrationBuilder.DropTable(
                name: "FileData");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Resource");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "ModelDifferences");

            migrationBuilder.DropTable(
                name: "PermissionPolicyTypePermissionObject");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "PermissionPolicyRoleBase");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "PermissionPolicyUser");

            migrationBuilder.DropTable(
                name: "StateMachineStates");

            migrationBuilder.DropTable(
                name: "StateMachines");
        }
    }
}
