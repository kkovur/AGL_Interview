using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AglInterviewTest.Models
{
    [SitecoreType(TemplateName ="Home")]
    public interface IPageInfo : IGlassBase
    {
        [SitecoreField]
        string Title { get; set; }
        [SitecoreField]
        string Heading { get; set; }
        [SitecoreField]
        string Description { get; set; }
        [SitecoreField("APIUrl")]
        Link ApiUrl { get; set; }
    }
}
