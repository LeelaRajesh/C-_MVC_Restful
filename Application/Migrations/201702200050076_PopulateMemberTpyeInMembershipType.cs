namespace MVCappli_rest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMemberTpyeInMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes set MemberType='Pay as You Go' WHERE Id=1");
            Sql("Update MembershipTypes set MemberType='Monthly' WHERE Id=2");
            Sql("Update MembershipTypes set MemberType='Quarterly' WHERE Id=3");
            Sql("Update MembershipTypes set MemberType='Yearly' WHERE Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
