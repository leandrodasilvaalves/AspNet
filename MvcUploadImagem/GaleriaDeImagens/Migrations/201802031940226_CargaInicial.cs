namespace GaleriaDeImagens.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CargaInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        PhotoId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        ImagePath = c.String(),
                        ThumbPath = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PhotoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Photos");
        }
    }
}
