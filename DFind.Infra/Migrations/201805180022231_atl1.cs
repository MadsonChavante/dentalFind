namespace DFind.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atl1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produto", "Economia", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Produto", "MelhorConsulta", c => c.Int());
            AlterColumn("dbo.Produto", "PiorConsulta", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produto", "PiorConsulta", c => c.Int(nullable: false));
            AlterColumn("dbo.Produto", "MelhorConsulta", c => c.Int(nullable: false));
            AlterColumn("dbo.Produto", "Economia", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
