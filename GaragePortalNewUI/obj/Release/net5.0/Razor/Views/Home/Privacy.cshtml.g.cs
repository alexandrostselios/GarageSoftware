#pragma checksum "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Home\Privacy.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "99923bb30ca53fc64ad14e608ed0eb1bc7e761f4a5cc72cb3784ec4d254b396b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Privacy), @"mvc.1.0.view", @"/Views/Home/Privacy.cshtml")]
namespace AspNetCore
{
    #line default
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\_ViewImports.cshtml"
using GaragePortalNewUI

#nullable disable
    ;
#nullable restore
#line 2 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\_ViewImports.cshtml"
using GaragePortalNewUI.Models

#line default
#line hidden
#nullable disable
    ;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"99923bb30ca53fc64ad14e608ed0eb1bc7e761f4a5cc72cb3784ec4d254b396b", @"/Views/Home/Privacy.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"da4eb8d6136306ebe2b493ae02b2be3e560331e9b2fef64dac5a5a7d88685240", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Privacy : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GaragePortalNewUI.Models.UserModels>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Home\Privacy.cshtml"
  
    ViewData["Title"] = Resource.GetKey("Privacy");

#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n\r\n");
#nullable restore
#line 8 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Home\Privacy.cshtml"
 if (@ViewBag.UserType == GaragePortalNewUI.Enum.UserType.Admin.ToString())
{

#line default
#line hidden
#nullable disable

            WriteLiteral("    <p>Welcome ");
            Write(
#nullable restore
#line 10 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Home\Privacy.cshtml"
                ViewBag.UserType

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(" - ");
            Write(
#nullable restore
#line 10 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Home\Privacy.cshtml"
                                    ViewBag.ID

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(" - ");
            Write(
#nullable restore
#line 10 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Home\Privacy.cshtml"
                                                  ViewBag.Name

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(" - ");
            Write(
#nullable restore
#line 10 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Home\Privacy.cshtml"
                                                                  ViewBag.Surname

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</p>\r\n    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
            Write(
#nullable restore
#line 15 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Home\Privacy.cshtml"
                     Html.DisplayNameFor(model => model.ID)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            Write(
#nullable restore
#line 18 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Home\Privacy.cshtml"
                     Html.DisplayNameFor(model => model.UserID)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            Write(
#nullable restore
#line 21 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Home\Privacy.cshtml"
                     Html.DisplayNameFor(model => model.ModelName)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 27 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Home\Privacy.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable

            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
            Write(
#nullable restore
#line 31 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Home\Privacy.cshtml"
                         Html.DisplayFor(modelItem => item.ID)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            Write(
#nullable restore
#line 34 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Home\Privacy.cshtml"
                         Html.DisplayFor(modelItem => item.UserID)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            Write(
#nullable restore
#line 37 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Home\Privacy.cshtml"
                         Html.DisplayFor(modelItem => item.ModelName)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 40 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Home\Privacy.cshtml"
            }

#line default
#line hidden
#nullable disable

            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 43 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Home\Privacy.cshtml"
}
else if (@ViewBag.UserType == GaragePortalNewUI.Enum.UserType.User.ToString())
{

#line default
#line hidden
#nullable disable

            WriteLiteral("    <p>Welcome user: ");
            Write(
#nullable restore
#line 46 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Home\Privacy.cshtml"
                      ViewBag.Name

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(" - ");
            Write(
#nullable restore
#line 46 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Home\Privacy.cshtml"
                                      ViewBag.Surname

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</p>\r\n");
#nullable restore
#line 47 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Home\Privacy.cshtml"

}
else
{

#line default
#line hidden
#nullable disable

            WriteLiteral("    <p>You need to login first</p>\r\n");
#nullable restore
#line 52 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Home\Privacy.cshtml"
}

#line default
#line hidden
#nullable disable

        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public 
#nullable restore
#line 2 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Home\Privacy.cshtml"
        LanguageService

#line default
#line hidden
#nullable disable
         
#nullable restore
#line 2 "C:\Users\alexa\Desktop\Visual Studio Projects\GarageSoftware - New Entities\GaragePortalNewUI\Views\Home\Privacy.cshtml"
                        Resource

#line default
#line hidden
#nullable disable
         { get; private set; }
         = default!;
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GaragePortalNewUI.Models.UserModels>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
