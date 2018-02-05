namespace CrudMariaDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pessoas", "Nome", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pessoas", "Nome", c => c.String());
        }
    }
}
