namespace BlueBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class courseratingchange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CourseRating", "CourseName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CourseRating", "CourseName", c => c.String(nullable: false));
        }
    }
}
