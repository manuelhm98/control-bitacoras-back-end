namespace ControlBitacorasESFE.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationForBitacorasEmp : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bitacoras", "FechaHora", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bitacoras", "FechaHora", c => c.DateTime(nullable: false));
        }
    }
}
