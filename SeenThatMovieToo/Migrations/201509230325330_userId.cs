namespace MvcApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userId : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "userId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "userId", c => c.Int(nullable: false));
        }
    }
}
