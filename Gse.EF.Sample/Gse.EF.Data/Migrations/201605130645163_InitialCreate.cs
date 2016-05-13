namespace Gse.EF.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.COM_EMPRESAS",
                c => new
                    {
                        OID = c.String(nullable: false, maxLength: 128),
                        ATR_CODIGO = c.String(),
                    })
                .PrimaryKey(t => t.OID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.COM_EMPRESAS");
        }
    }
}
