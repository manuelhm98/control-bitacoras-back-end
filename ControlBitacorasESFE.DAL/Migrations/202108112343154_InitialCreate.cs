namespace ControlBitacorasESFE.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        AreaID = c.Short(nullable: false, identity: true),
                        TipoAreaID = c.Short(nullable: false),
                        UsuarioID = c.Short(nullable: false),
                        NombreArea = c.String(nullable: false),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AreaID)
                .ForeignKey("dbo.TipoAreas", t => t.TipoAreaID)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioID)
                .Index(t => t.TipoAreaID)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.TipoAreas",
                c => new
                    {
                        TipoAreaID = c.Short(nullable: false, identity: true),
                        Tipo = c.String(nullable: false),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TipoAreaID);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioID = c.Short(nullable: false, identity: true),
                        RoleID = c.Short(nullable: false),
                        Nombre = c.String(nullable: false),
                        Apellido = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Pass = c.String(nullable: false),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioID)
                .ForeignKey("dbo.Roles", t => t.RoleID)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Short(nullable: false, identity: true),
                        Roles = c.String(nullable: false),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Bitacoras",
                c => new
                    {
                        BitacoraID = c.Long(nullable: false, identity: true),
                        PuestosTrabajoID = c.Long(nullable: false),
                        UsuarioID = c.Short(nullable: false),
                        FallaID = c.Long(nullable: false),
                        FechaHora = c.DateTime(nullable: false),
                        Comentario = c.String(nullable: false),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BitacoraID)
                .ForeignKey("dbo.Fallas", t => t.FallaID)
                .ForeignKey("dbo.PuestosTrabajoes", t => t.PuestosTrabajoID)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioID)
                .Index(t => t.PuestosTrabajoID)
                .Index(t => t.UsuarioID)
                .Index(t => t.FallaID);
            
            CreateTable(
                "dbo.Fallas",
                c => new
                    {
                        FallaID = c.Long(nullable: false, identity: true),
                        TipoFallaID = c.Short(nullable: false),
                        Descripcion = c.String(nullable: false),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FallaID)
                .ForeignKey("dbo.TipoFallas", t => t.TipoFallaID)
                .Index(t => t.TipoFallaID);
            
            CreateTable(
                "dbo.TipoFallas",
                c => new
                    {
                        TipoFallaID = c.Short(nullable: false, identity: true),
                        Tipo = c.String(nullable: false),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TipoFallaID);
            
            CreateTable(
                "dbo.PuestosTrabajoes",
                c => new
                    {
                        PuestosTrabajoID = c.Long(nullable: false, identity: true),
                        AreaID = c.Short(nullable: false),
                        MonitorID = c.Short(nullable: false),
                        UpsID = c.Short(nullable: false),
                        CpuID = c.Short(nullable: false),
                        MuebleID = c.Short(nullable: false),
                        Teclado = c.Boolean(nullable: false),
                        Mouse = c.Boolean(nullable: false),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PuestosTrabajoID)
                .ForeignKey("dbo.Areas", t => t.AreaID)
                .ForeignKey("dbo.Cpus", t => t.CpuID)
                .ForeignKey("dbo.Monitors", t => t.MonitorID)
                .ForeignKey("dbo.Muebles", t => t.MuebleID)
                .ForeignKey("dbo.Ups", t => t.UpsID)
                .Index(t => t.AreaID)
                .Index(t => t.MonitorID)
                .Index(t => t.UpsID)
                .Index(t => t.CpuID)
                .Index(t => t.MuebleID);
            
            CreateTable(
                "dbo.Cpus",
                c => new
                    {
                        CpuID = c.Short(nullable: false, identity: true),
                        ProcesadorID = c.Short(nullable: false),
                        Codigo = c.String(nullable: false),
                        Ram = c.String(nullable: false),
                        Almacenamiento = c.String(nullable: false),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CpuID)
                .ForeignKey("dbo.Procesadors", t => t.ProcesadorID)
                .Index(t => t.ProcesadorID);
            
            CreateTable(
                "dbo.Procesadors",
                c => new
                    {
                        ProcesadorID = c.Short(nullable: false, identity: true),
                        Modelo = c.String(nullable: false),
                        Velocidad = c.String(nullable: false),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProcesadorID);
            
            CreateTable(
                "dbo.Monitors",
                c => new
                    {
                        MonitorID = c.Short(nullable: false, identity: true),
                        Codigo = c.String(nullable: false),
                        Modelo = c.String(nullable: false),
                        Pulgadas = c.Int(nullable: false),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MonitorID);
            
            CreateTable(
                "dbo.Muebles",
                c => new
                    {
                        MuebleID = c.Short(nullable: false, identity: true),
                        Codigo = c.String(nullable: false),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MuebleID);
            
            CreateTable(
                "dbo.Ups",
                c => new
                    {
                        UpsID = c.Short(nullable: false, identity: true),
                        Codigo = c.String(nullable: false),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UpsID);
            
            CreateTable(
                "dbo.EquipoAreas",
                c => new
                    {
                        EquipoAreaID = c.Long(nullable: false, identity: true),
                        AreaID = c.Short(nullable: false),
                        Equipo = c.String(nullable: false),
                        Codigo = c.String(nullable: false),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EquipoAreaID)
                .ForeignKey("dbo.Areas", t => t.AreaID)
                .Index(t => t.AreaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EquipoAreas", "AreaID", "dbo.Areas");
            DropForeignKey("dbo.Bitacoras", "UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.Bitacoras", "PuestosTrabajoID", "dbo.PuestosTrabajoes");
            DropForeignKey("dbo.PuestosTrabajoes", "UpsID", "dbo.Ups");
            DropForeignKey("dbo.PuestosTrabajoes", "MuebleID", "dbo.Muebles");
            DropForeignKey("dbo.PuestosTrabajoes", "MonitorID", "dbo.Monitors");
            DropForeignKey("dbo.PuestosTrabajoes", "CpuID", "dbo.Cpus");
            DropForeignKey("dbo.Cpus", "ProcesadorID", "dbo.Procesadors");
            DropForeignKey("dbo.PuestosTrabajoes", "AreaID", "dbo.Areas");
            DropForeignKey("dbo.Bitacoras", "FallaID", "dbo.Fallas");
            DropForeignKey("dbo.Fallas", "TipoFallaID", "dbo.TipoFallas");
            DropForeignKey("dbo.Areas", "UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.Usuarios", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Areas", "TipoAreaID", "dbo.TipoAreas");
            DropIndex("dbo.EquipoAreas", new[] { "AreaID" });
            DropIndex("dbo.Cpus", new[] { "ProcesadorID" });
            DropIndex("dbo.PuestosTrabajoes", new[] { "MuebleID" });
            DropIndex("dbo.PuestosTrabajoes", new[] { "CpuID" });
            DropIndex("dbo.PuestosTrabajoes", new[] { "UpsID" });
            DropIndex("dbo.PuestosTrabajoes", new[] { "MonitorID" });
            DropIndex("dbo.PuestosTrabajoes", new[] { "AreaID" });
            DropIndex("dbo.Fallas", new[] { "TipoFallaID" });
            DropIndex("dbo.Bitacoras", new[] { "FallaID" });
            DropIndex("dbo.Bitacoras", new[] { "UsuarioID" });
            DropIndex("dbo.Bitacoras", new[] { "PuestosTrabajoID" });
            DropIndex("dbo.Usuarios", new[] { "RoleID" });
            DropIndex("dbo.Areas", new[] { "UsuarioID" });
            DropIndex("dbo.Areas", new[] { "TipoAreaID" });
            DropTable("dbo.EquipoAreas");
            DropTable("dbo.Ups");
            DropTable("dbo.Muebles");
            DropTable("dbo.Monitors");
            DropTable("dbo.Procesadors");
            DropTable("dbo.Cpus");
            DropTable("dbo.PuestosTrabajoes");
            DropTable("dbo.TipoFallas");
            DropTable("dbo.Fallas");
            DropTable("dbo.Bitacoras");
            DropTable("dbo.Roles");
            DropTable("dbo.Usuarios");
            DropTable("dbo.TipoAreas");
            DropTable("dbo.Areas");
        }
    }
}
