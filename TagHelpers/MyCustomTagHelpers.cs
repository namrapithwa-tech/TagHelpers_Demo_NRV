using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpers_Demo_NRV.TagHelpers
{
    [HtmlTargetElement("Namra")] //Target Element 
    public class MyCustomTagHelpers:TagHelper
    {
        public string path { get; set; }
        public string altText { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "img"; // no return in index
            output.TagMode = TagMode.StartTagAndEndTag;

            output.Attributes.SetAttribute("src", path);
            output.Attributes.SetAttribute("alt", altText);

            if (!string.IsNullOrEmpty(Width))
                output.Attributes.SetAttribute("width", Width);

            if (!string.IsNullOrEmpty(Height))
                output.Attributes.SetAttribute("height", Height);
            
            base.Process(context, output);
        }
    }
}
