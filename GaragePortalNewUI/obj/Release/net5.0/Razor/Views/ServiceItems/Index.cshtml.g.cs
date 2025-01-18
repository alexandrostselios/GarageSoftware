#pragma checksum "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware\GaragePortalNewUI\Views\ServiceItems\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4e4792d30bbe9c3f50b941a58150c61ddc502b75"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ServiceItems_Index), @"mvc.1.0.view", @"/Views/ServiceItems/Index.cshtml")]
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
#line 1 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware\GaragePortalNewUI\Views\_ViewImports.cshtml"
using GaragePortalNewUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware\GaragePortalNewUI\Views\_ViewImports.cshtml"
using GaragePortalNewUI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e4792d30bbe9c3f50b941a58150c61ddc502b75", @"/Views/ServiceItems/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85a55a5ae804c6c3cc1a0dc4b198905acee6ca2c", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_ServiceItems_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GaragePortalNewUI.Models.ServiceItems>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware\GaragePortalNewUI\Views\ServiceItems\Index.cshtml"
  
    //ViewData["Title"] = @Resource.GetKey("List_of_Customers");
    ViewData["Title"] = "Service Items";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 9 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware\GaragePortalNewUI\Views\ServiceItems\Index.cshtml"
 if (@ViewBag.UserType == GaragePortalNewUI.Enum.UserType.Admin.ToString())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
#nullable restore
#line 45 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware\GaragePortalNewUI\Views\ServiceItems\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    Description\r\n                </th>\r\n                <th colspan=\"2\">Total Service Items: ");
#nullable restore
#line 50 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware\GaragePortalNewUI\Views\ServiceItems\Index.cshtml"
                                                Write(Model.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 54 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware\GaragePortalNewUI\Views\ServiceItems\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 58 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware\GaragePortalNewUI\Views\ServiceItems\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 61 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware\GaragePortalNewUI\Views\ServiceItems\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        <button class=\"btn btn-sm btn-primary m-2\" id=\"btnEditCustomer\" data-bs-toggle=\"ajax-modal\" data-bs-target=\"#EditCustomer\" data-url=\"");
#nullable restore
#line 64 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware\GaragePortalNewUI\Views\ServiceItems\Index.cshtml"
                                                                                                                                                        Write(Url.Action("EditCustomerPartial",new{id = @item.ID}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 64 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware\GaragePortalNewUI\Views\ServiceItems\Index.cshtml"
                                                                                                                                                                                                               Write(Resource.GetKey("Edit"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n                    </td>\r\n                    <td>\r\n                        <button class=\"btn btn-sm btn-danger m-2\" id=\"btnEditCustomer\" data-bs-toggle=\"ajax-modal\" data-bs-target=\"#EditCustomer\" data-url=\"");
#nullable restore
#line 67 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware\GaragePortalNewUI\Views\ServiceItems\Index.cshtml"
                                                                                                                                                       Write(Url.Action("EditCustomerPartial",new{id = @item.ID}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 67 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware\GaragePortalNewUI\Views\ServiceItems\Index.cshtml"
                                                                                                                                                                                                              Write(Resource.GetKey("Delete"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n                    </td>\r\n                    <td colspan =\"3\"></td>\r\n                </tr>\r\n");
#nullable restore
#line 71 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware\GaragePortalNewUI\Views\ServiceItems\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 74 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware\GaragePortalNewUI\Views\ServiceItems\Index.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p><center>You are not authorized to access this page</center></p>\r\n");
#nullable restore
#line 78 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware\GaragePortalNewUI\Views\ServiceItems\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public LanguageService Resource { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GaragePortalNewUI.Models.ServiceItems>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
