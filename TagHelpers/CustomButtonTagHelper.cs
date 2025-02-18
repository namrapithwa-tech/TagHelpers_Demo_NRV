using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpers_Demo_NRV.TagHelpers
{
    [HtmlTargetElement("custom-button")] // Custom tag: <custom-button>
    public class CustomButtonTagHelper : TagHelper
    {
        public string Text { get; set; } = "Click Me";
        public string Background { get; set; } = "primary"; // Default Bootstrap background
        public string Size { get; set; } = "md"; // Bootstrap size (sm, md, lg)
        public bool Outline { get; set; } = false; // Outline style or not
        public string OnClick { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "button";
            output.TagMode = TagMode.StartTagAndEndTag;

            // Bootstrap class logic
            string buttonClass = Outline ?
                $"btn btn-outline-{Background}" :
                $"btn btn-{Background}";

            // Add size class
            if (!string.IsNullOrEmpty(Size) && Size != "md")
            {
                buttonClass += $" btn-{Size}";
            }

            output.Attributes.SetAttribute("class", buttonClass);

            // Add onclick event if provided
            if (!string.IsNullOrEmpty(OnClick))
            {
                output.Attributes.SetAttribute("onclick", OnClick);
            }

            // Set button text
            output.Content.SetContent(Text);
        }
    }
}
