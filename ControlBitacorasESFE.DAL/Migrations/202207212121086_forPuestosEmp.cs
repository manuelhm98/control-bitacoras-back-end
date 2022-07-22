namespace ControlBitacorasESFE.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forPuestosEmp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PuestosTrabajoes", "Codigo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PuestosTrabajoes", "Codigo");
        }
    }
}
