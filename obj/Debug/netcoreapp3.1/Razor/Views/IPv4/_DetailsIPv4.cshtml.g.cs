#pragma checksum "C:\Users\Sanna\Desktop\IPbag\IPBag_final\IPBag\Views\IPv4\_DetailsIPv4.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "18b56ec6149dbddebad2f4076d40439a6a159a61"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_IPv4__DetailsIPv4), @"mvc.1.0.view", @"/Views/IPv4/_DetailsIPv4.cshtml")]
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
#line 1 "C:\Users\Sanna\Desktop\IPbag\IPBag_final\IPBag\Views\_ViewImports.cshtml"
using IPBag;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Sanna\Desktop\IPbag\IPBag_final\IPBag\Views\_ViewImports.cshtml"
using IPBag.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"18b56ec6149dbddebad2f4076d40439a6a159a61", @"/Views/IPv4/_DetailsIPv4.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf839bf5e498aa3cc31a3851c3e31b99bd2bb588", @"/Views/_ViewImports.cshtml")]
    public class Views_IPv4__DetailsIPv4 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IPv4Addresses>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
    <div class=""modal-header"">
        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close""><span aria-hidden=""true"">&times;</span></button>
    </div>
    <div class=""modal-body"">
        <h1>Details</h1>
        <dl class=""row"">
            <dt class=""col-sm-2"">
                ");
#nullable restore
#line 10 "C:\Users\Sanna\Desktop\IPbag\IPBag_final\IPBag\Views\IPv4\_DetailsIPv4.cshtml"
           Write(Html.DisplayNameFor(modelItem => Model.AFrom));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dh class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 13 "C:\Users\Sanna\Desktop\IPbag\IPBag_final\IPBag\Views\IPv4\_DetailsIPv4.cshtml"
           Write(Html.DisplayFor(modelItem => Model.AFrom));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dh>\r\n\r\n            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 17 "C:\Users\Sanna\Desktop\IPbag\IPBag_final\IPBag\Views\IPv4\_DetailsIPv4.cshtml"
           Write(Html.DisplayNameFor(modelItem => Model.ATo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dh class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 20 "C:\Users\Sanna\Desktop\IPbag\IPBag_final\IPBag\Views\IPv4\_DetailsIPv4.cshtml"
           Write(Html.DisplayFor(modelItem => Model.ATo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dh>\r\n\r\n            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 24 "C:\Users\Sanna\Desktop\IPbag\IPBag_final\IPBag\Views\IPv4\_DetailsIPv4.cshtml"
           Write(Html.DisplayNameFor(modelItem => Model.UserEmail));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dh class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 27 "C:\Users\Sanna\Desktop\IPbag\IPBag_final\IPBag\Views\IPv4\_DetailsIPv4.cshtml"
           Write(Html.DisplayFor(modelItem => Model.UserEmail));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dh>\r\n\r\n            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 31 "C:\Users\Sanna\Desktop\IPbag\IPBag_final\IPBag\Views\IPv4\_DetailsIPv4.cshtml"
           Write(Html.DisplayNameFor(modelItem => Model.Notes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dh class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 34 "C:\Users\Sanna\Desktop\IPbag\IPBag_final\IPBag\Views\IPv4\_DetailsIPv4.cshtml"
           Write(Html.DisplayFor(modelItem => Model.Notes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dh>\r\n        </dl>\r\n\r\n        <div class=\"modal-footer\">\r\n            <button type=\"button\" class=\"btn btn-default\" data-dismiss=\"modal\">Close</button>\r\n        </div>\r\n    </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IPv4Addresses> Html { get; private set; }
    }
}
#pragma warning restore 1591
