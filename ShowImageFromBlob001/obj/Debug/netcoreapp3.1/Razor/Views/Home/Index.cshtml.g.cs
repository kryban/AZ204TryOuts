#pragma checksum "D:\Leren\AZ-204\docker\ContainerApp\ShowImageFromBlob001\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "95c76c568d88c735406bb200adca05ba74e2c524"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Leren\AZ-204\docker\ContainerApp\ShowImageFromBlob001\Views\_ViewImports.cshtml"
using StorageShowImageFromBlob001;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Leren\AZ-204\docker\ContainerApp\ShowImageFromBlob001\Views\_ViewImports.cshtml"
using StorageShowImageFromBlob001.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"95c76c568d88c735406bb200adca05ba74e2c524", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5a3ef2bb0c50e9198e90d6f26c20ef7eee9f48f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<StorageShowImageFromBlob001.Models.BlobImage>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Leren\AZ-204\docker\ContainerApp\ShowImageFromBlob001\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Welcome to the ");
#nullable restore
#line 8 "D:\Leren\AZ-204\docker\ContainerApp\ShowImageFromBlob001\Views\Home\Index.cshtml"
                                    Write(Model.BlobImageName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" presenter. </h1>\r\n    <p><img");
            BeginWriteAttribute("src", " src=\"", 220, "\"", 245, 1);
#nullable restore
#line 9 "D:\Leren\AZ-204\docker\ContainerApp\ShowImageFromBlob001\Views\Home\Index.cshtml"
WriteAttributeValue("", 226, Model.BlobImageUrl, 226, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("/></p>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<StorageShowImageFromBlob001.Models.BlobImage> Html { get; private set; }
    }
}
#pragma warning restore 1591
