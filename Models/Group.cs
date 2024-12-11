using System.Collections.Generic;

public class Group
{
    public int GroupID { get; set; } // Primary Key
    public string GroupName { get; set; } // Name of the group
    public int? ParentGroupID { get; set; } // Allows linking to a parent group (nullable)
    public Group ParentGroup { get; set; } // Navigation property for the parent group
    public List<Group> SubGroups { get; set; } // List of subgroups
}