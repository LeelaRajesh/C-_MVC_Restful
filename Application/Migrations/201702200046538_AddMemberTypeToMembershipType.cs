namespace MVCappli_rest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMemberTypeToMembershipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "MemberType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "MemberType");
        }
    }
}
