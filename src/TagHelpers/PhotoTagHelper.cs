﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using PhotoGallery.Models;

namespace PhotoGallery.TagHelpers
{
    [HtmlTargetElement("img", Attributes = "photo, type")]
    public class PhotoTagHelper : TagHelper
    {
        public Photo Photo { get; set; }
        public ImageType Type { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string thumbnail = Photo.GetThumbnailLink((int)Type, out int height);

            output.Attributes.Add("width", (int)Type);
            output.Attributes.Add("height", height);
            output.Attributes.Add("alt", Photo.DisplayName);
            output.Attributes.Add("src", "/img/_.gif");

            // This is for lazy loading in album view
            if (Type != ImageType.Full)
            {
                output.Attributes.Add("data-echo", $"{thumbnail}");
            }
        }
    }

}
