#pragma checksum "C:\Users\toklu\Desktop\Local-Projects\DotNetProjects\Librar\V2\LibraryMVC-V2\library.webui\Views\Book\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bca9ef289fb5510ac6bfb1c75512098cf2548a81"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Book_Details), @"mvc.1.0.view", @"/Views/Book/Details.cshtml")]
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
#line 3 "C:\Users\toklu\Desktop\Local-Projects\DotNetProjects\Librar\V2\LibraryMVC-V2\library.webui\Views\_ViewImports.cshtml"
using library.webui.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\toklu\Desktop\Local-Projects\DotNetProjects\Librar\V2\LibraryMVC-V2\library.webui\Views\_ViewImports.cshtml"
using library.entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\toklu\Desktop\Local-Projects\DotNetProjects\Librar\V2\LibraryMVC-V2\library.webui\Views\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bca9ef289fb5510ac6bfb1c75512098cf2548a81", @"/Views/Book/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0285da79f798e9d91a6ad965ef4ccb773042bf64", @"/Views/_ViewImports.cshtml")]
    public class Views_Book_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Book>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"card mb-3\">\r\n    <div class=\"card-body\">\r\n        <div class=\"row no-gutters\">\r\n            <div class=\"col-md-3\">\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 163, "\"", 184, 1);
#nullable restore
#line 7 "C:\Users\toklu\Desktop\Local-Projects\DotNetProjects\Librar\V2\LibraryMVC-V2\library.webui\Views\Book\Details.cshtml"
WriteAttributeValue("", 169, Model.ImageUrl, 169, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img\">\r\n            </div>\r\n            <div class=\"col-md-9\">\r\n                <h5 class=\"card-title\">");
#nullable restore
#line 10 "C:\Users\toklu\Desktop\Local-Projects\DotNetProjects\Librar\V2\LibraryMVC-V2\library.webui\Views\Book\Details.cshtml"
                                  Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                <p class=\"card-text\">");
#nullable restore
#line 11 "C:\Users\toklu\Desktop\Local-Projects\DotNetProjects\Librar\V2\LibraryMVC-V2\library.webui\Views\Book\Details.cshtml"
                                Write(Html.Raw(@Model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">\r\n                    <small class=\"text-muted\">3 days ago</small>\r\n                </p>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Book> Html { get; private set; }
    }
}
#pragma warning restore 1591
