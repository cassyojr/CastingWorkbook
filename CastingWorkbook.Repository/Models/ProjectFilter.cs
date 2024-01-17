using CastingWorkbook.Repository.Enums;

namespace CastingWorkbook.Repository.Models;

public class ProjectFilter
{
    public List<ProjectUnionEnum>? ProjectUnion { get; set; }
    public ProjectTypeEnum? ProjectType { get; set; }
    public SortOrderEnum? SortOrder { get; set; }
}
